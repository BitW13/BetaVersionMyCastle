using Common.Helpers;
using Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskPlannerService.Bll.BusinessLogic.Implementations;
using TaskPlannerService.Bll.BusinessLogic.Interfaces;
using TaskPlannerService.Bll.Services.Implementations;
using TaskPlannerService.Bll.Services.Interfaces;
using TaskPlannerService.Dal.DataAccess.Implementations;
using TaskPlannerService.Dal.DataAccess.Interfaces;
using TaskPlannerService.Dal.Repositories.Implementations;
using TaskPlannerService.Dal.Repositories.Interfaces;
using TaskPlannerService.PL;
using TaskPlannerService.PL.Severities;
using TaskPlannerService.PL.TaskCards;
using TaskPlannerService.PL.TaskCategories;

namespace TaskPlannerService.DI
{
    public static class IoC
    {
        public static void IoCCommonRegister(this IServiceCollection services, IConfiguration configuration)
        {           
            services.AddTransient<IContext, ServiceContext>();

            services.AddTransient<IDataAccess, DataAccess>();
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<ITaskCategoryRepository, TaskCategoryRepository>();
            services.AddTransient<ISeverityRepository, SeverityRepository>();

            services.AddTransient<IBusinessLogic, BusinessLogic>();
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<ITaskCategoryService, TaskCategoryService>();
            services.AddTransient<ISeverityService, SeverityService>();

            services.AddTransient<IPresenterLayer, PresenterLayer>();
            services.AddTransient<ITaskCardPresenter, TaskCardPresenter>();
            services.AddTransient<ITaskCategoryPresenter, TaskCategoryPresenter>();
            services.AddTransient<ISeverityPresenter, SeverityPresenter>();
        }
    }
}
