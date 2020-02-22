using Microsoft.EntityFrameworkCore;
using MVCProjectFinal.Core.Context;
using MVCProjectFinal.Core.Repository;
using MVCProjectFinal.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCProjectFinal.Core.UnitOfWork
{
    public class FileUploadUnitOfWork : UnitOfWork<FileUploadContext>, IFileUploadUnitOfWork
    {
        public IFileUploadRepository FileUploadRepository { get; set; }

        public FileUploadUnitOfWork(string connectionString, string migrationAssemblyName )
            : base(connectionString, migrationAssemblyName)
        {
            FileUploadRepository = new FileUploadRepository(_dbContext);
        }
    }
}
