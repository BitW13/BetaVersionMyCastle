using Common.Entity.TaskPlannerService;
using System.Collections.Generic;
using System.Linq;
using TaskPlannerService.Bll.Services.Interfaces;
using TaskPlannerService.Dal.Repositories.Interfaces;

namespace TaskPlannerService.Bll.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository db;

        public TaskService(ITaskRepository db)
        {
            this.db = db;
        }

        public TaskEntity Create(TaskEntity item)
        {
            db.Create(item);

            var items = GetAll().ToList();

            return items[items.Count - 1];
        }

        public bool Delete(int id)
        {
            return db.Delete(id);
        }

        public IEnumerable<TaskEntity> GetAll()
        {
            return db.GetAll();
        }

        public IEnumerable<TaskEntity> GetBySeverityId(int severityId)
        {
            return db.GetBySeverityId(severityId);
        }

        public IEnumerable<TaskEntity> GetByTaskCategoryId(int taskCategoryId)
        {
            return db.GetByTaskCategoryId(taskCategoryId);
        }

        public TaskEntity GetItemById(int id)
        {
            return db.GetItemById(id);
        }

        public void Update(TaskEntity item)
        {
            db.Update(item);
        }
    }
}
