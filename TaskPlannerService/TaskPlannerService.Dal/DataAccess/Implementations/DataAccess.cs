using TaskPlannerService.Dal.DataAccess.Interfaces;
using TaskPlannerService.Dal.Repositories.Interfaces;

namespace TaskPlannerService.Dal.DataAccess.Implementations
{
    public class DataAccess : IDataAccess
    {
        public DataAccess(ITaskRepository tasks, ITaskCategoryRepository taskCategories, ISeverityRepository severities)
        {
            Tasks = tasks;
            TaskCategories = taskCategories;
            Severities = severities;
        }

        public ITaskRepository Tasks { get; set; }
        public ITaskCategoryRepository TaskCategories { get; set; }
        public ISeverityRepository Severities { get; set; }
    }
}
