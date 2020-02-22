using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcProjectFinal.Web.Areas.Admin.Models;
using MvcProjectFinal.Web.Models;
using MVCProjectFinal.Core.Entity;

namespace MvcProjectFinal.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class RoleController : Controller
    {
        private readonly UserManager<ExtendedIdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RoleController> _logger;

        public RoleController(
            UserManager<ExtendedIdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<RoleController> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }


        [Authorize(Policy = "CityUsersOnly")]
        public IActionResult Index()
        {
            var model = new RoleViewModel();    
            return View(model);
        }

        public IActionResult GetRoles()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new RoleViewModel();
            var data = model.GetRoles(tableModel);
            return Json(data);
        }


        [Authorize(Policy = "InternalOfficials")]
        public IActionResult Add()
        {
            var model = new RoleUpdateModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(RoleUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                await model.AddNewRole();
            }
            return View(model);
        }
    }
}