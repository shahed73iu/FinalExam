using Microsoft.EntityFrameworkCore;
using MVCProjectFinal.Core.Entity;
using MVCProjectFinal.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCProjectFinal.Core.Repository
{
    public class FileUploadRepository : Repository<FileDetails> , IFileUploadRepository
    {
        public FileUploadRepository(DbContext dbContext)
            :base(dbContext)
        {

        }
    }
}
