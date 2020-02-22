using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.SQS;
using Amazon.SQS.Model;
using CsvHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcProjectFinal.Web.Areas.Admin.Models;

namespace MvcProjectFinal.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
           var model = new FileUpdateModel();
            return View(model);
        }

         [HttpPost]
         public async Task<IActionResult> Add(IFormFile csvFile)
         {
             var randomName = Path.GetRandomFileName().Replace(".", "");
             var fileName = System.IO.Path.GetFileName(csvFile.FileName);
             var newFileName = $"{ randomName }{ Path.GetExtension(csvFile.FileName)}";

             var path = $"upload/{randomName}{Path.GetExtension(csvFile.FileName)}";
           
            if (!System.IO.File.Exists(path))
            {
                using (var imageFile = System.IO.File.OpenWrite(path))
                {
                    using (var uploadedfile = csvFile.OpenReadStream())
                    {
                        uploadedfile.CopyTo(imageFile);

                    }
                }
            }

            var client = new AmazonS3Client();

             var file = new FileInfo(path);
             var request = new PutObjectRequest
             {
                 BucketName = "practicenet",
                 FilePath = file.FullName,
                 Key = newFileName
             };

             var response = await client.PutObjectAsync(request);

             if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
             {
                var model = new FileUpdateModel();
                model.AddFiledetails(newFileName);
             }

             return View();
         }
         

    }
}