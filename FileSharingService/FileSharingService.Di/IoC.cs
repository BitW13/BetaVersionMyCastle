using Common.Helpers;
using Common.Interfaces;
using FileSharingService.Bll.BusinessLogic;
using FileSharingService.Bll.Services.Implementations;
using FileSharingService.Bll.Services.Interfaces;
using FileSharingService.Dal.DataAccess;
using FileSharingService.Dal.Repositories.Implementations;
using FileSharingService.Dal.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileSharingService.Di
{
    public static class IoC
    {
        public static void IoCCommonRegister(this IServiceCollection services)
        {
            services.AddTransient<IContext, ServiceContext>();

            services.AddTransient<IDataAccess, DataAccess>();
            services.AddTransient<IFileAccessRepository, FileAccessRepository>();
            services.AddTransient<IFileCategoryRepository, FileCategoryRepository>();
            services.AddTransient<IFileRepository, FileRepository>();
            services.AddTransient<IFileUrlRepository, FileUrlRepository>();

            services.AddTransient<IBusinessLogic, BusinessLogic>();
            services.AddTransient<IFileAccessService, FileAccessService>();
            services.AddTransient<IFileCategoryService, FileCategoryService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IFileUrlService, FileUrlService>();
        }
    }
}
