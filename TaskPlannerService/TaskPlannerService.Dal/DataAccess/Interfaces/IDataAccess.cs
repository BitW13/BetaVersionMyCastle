using TaskPlannerService.Dal.Repositories.Interfaces;

namespace TaskPlannerService.Dal.DataAccess.Interfaces
{
    public interface IDataAccess
    {
        ITaskRepository Tasks { get; set; }

        ITaskCategoryRepository TaskCategories { get; set; }

        ISeverityRepository Severities { get; set; }
    }
}
