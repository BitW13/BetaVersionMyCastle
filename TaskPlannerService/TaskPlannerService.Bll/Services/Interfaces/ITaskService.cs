using Common.Entity.TaskPlannerService;
using Common.Patterns.Repository;
using System.Collections.Generic;

namespace TaskPlannerService.Bll.Services.Interfaces
{
    public interface ITaskService : IService<TaskEntity>
    {
        IEnumerable<TaskEntity> GetByTaskCategoryId(int taskCategoryId);

        IEnumerable<TaskEntity> GetBySeverityId(int severityId);
    }
}
