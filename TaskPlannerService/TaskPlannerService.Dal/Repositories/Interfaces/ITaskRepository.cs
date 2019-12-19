using Common.Entity.TaskPlannerService;
using Common.Patterns.Repository;
using System.Collections.Generic;

namespace TaskPlannerService.Dal.Repositories.Interfaces
{
    public interface ITaskRepository : IRepository<TaskEntity>
    {
        IEnumerable<TaskEntity> GetByTaskCategoryId(int taskCategoryId);

        IEnumerable<TaskEntity> GetBySeverityId(int severityId);
    }
}
