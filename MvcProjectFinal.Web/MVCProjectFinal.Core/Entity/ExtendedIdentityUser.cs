using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCProjectFinal.Core.Entity
{
    public class ExtendedIdentityUser : IdentityUser
    {
        public DateTime LastLogin { get; set; }
        public string City { get; set; }
    }
}
