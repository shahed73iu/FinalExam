using MVCProjectFinal.Core.Context;
using MVCProjectFinal.Core.Repository;
using MVCProjectFinal.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCProjectFinal.Core.UnitOfWork
{
    public interface IFileUploadUnitOfWork : IUnitOfWork<FileUploadContext>
    {
        IFileUploadRepository FileUploadRepository { get; set; }  
    }
}
