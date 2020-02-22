using Autofac;
using Microsoft.Extensions.Configuration;
using MVCProjectFinal.Core.Context;
using MVCProjectFinal.Core.Repository;
using MVCProjectFinal.Core.Services;
using MVCProjectFinal.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCProjectFinal.Core
{
    public class CoreModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        private readonly IConfiguration _configuration;

        public CoreModule(IConfiguration configuration, string connectionStringName, string migrationAssemblyName)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString(connectionStringName);
            _migrationAssemblyName = migrationAssemblyName;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FileUploadContext>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();

            builder.RegisterType<FileUploadContext>().As<IFileUploadContext>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();

            builder.RegisterType<FileUploadUnitOfWork>().As<IFileUploadUnitOfWork> ()
                  .WithParameter("connectionString", _connectionString)
                  .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                  .InstancePerLifetimeScope();

            builder.RegisterType<FileUploadService>().As<IFileUploadService>()
                 .InstancePerLifetimeScope();
            builder.RegisterType<FileUploadRepository>().As<IFileUploadRepository>()
                .InstancePerLifetimeScope();


            base.Load(builder);
        }
    }
}

