using TaskPlannerService.Bll.BusinessLogic.Interfaces;
using TaskPlannerService.Bll.Services.Interfaces;

namespace TaskPlannerService.Bll.BusinessLogic.Implementations
{
    public class BusinessLogic : IBusinessLogic
    {
        public BusinessLogic(ITaskService tasks, ITaskCategoryService taskCategories, ISeverityService severities)
        {
            Tasks = tasks;
            Categories = taskCategories;
            Severities = severities;
        }

        public ITaskService Tasks { get; set; }
        public ITaskCategoryService Categories { get; set; }
        public ISeverityService Severities { get; set; }
    }
}
