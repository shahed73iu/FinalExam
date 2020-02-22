using Microsoft.EntityFrameworkCore;
using MVCProjectFinal.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCProjectFinal.Core.Context
{
    public interface IFileUploadContext
    {
        DbSet<FileDetails> FileDetails { get; set; }

    }
}
