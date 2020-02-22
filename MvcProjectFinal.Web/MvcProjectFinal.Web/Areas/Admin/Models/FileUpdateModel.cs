using Autofac;
using MVCProjectFinal.Core.Entity;
using MVCProjectFinal.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProjectFinal.Web.Areas.Admin.Models
{
    public class FileUpdateModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public string Status { get; set; }


        private IFileUploadService _fileUploadService; 
        public FileUpdateModel()
        {
            _fileUploadService = Startup.AutofacContainer.Resolve<IFileUploadService>();
        }
        public FileUpdateModel(IFileUploadService fileUpdateService)
        {
            _fileUploadService = fileUpdateService;
        }

        public void AddFiledetails(string filename)
        {
            try
            {
                _fileUploadService.AddFileDetails(new FileDetails
                {
                    Name = filename,
                    Time = DateTime.UtcNow,
                    Status = "Pending"
                });
            }
            catch(Exception ex)
            {
                throw new NullReferenceException();
            }
        }
    }
}
