using System;
using System.Collections.Generic;
using System.Text;
using MVCProjectFinal.Core.Entity;
using MVCProjectFinal.Core.UnitOfWork;

namespace MVCProjectFinal.Core.Services
{
    public class FileUploadService : IFileUploadService
    {
        private FileUploadUnitOfWork _fileUploadUnitOfWork;
        public FileUploadService(FileUploadUnitOfWork fileUploadUnitOfWork)
        {
            _fileUploadUnitOfWork = fileUploadUnitOfWork;
        }

        public void AddFileDetails(FileDetails fileDetails)
        {
            if(fileDetails == null || string.IsNullOrEmpty(fileDetails.Name))
                throw new InvalidOperationException("File name is missing");
            
            _fileUploadUnitOfWork.FileUploadRepository.Add(fileDetails);
            _fileUploadUnitOfWork.Save();
        }
    }
}
