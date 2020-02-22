using Microsoft.EntityFrameworkCore;
using MVCProjectFinal.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCProjectFinal.Core.Context
{
    public class FileUploadContext : DbContext, IFileUploadContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public FileUploadContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }
            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<FileDetails> FileDetails { get; set; }
    }
}
