using MVCProjectFinal.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCProjectFinal.Core.Services
{
    public interface IFileUploadService
    {
        void AddFileDetails(FileDetails fileDetails);
    }
}
