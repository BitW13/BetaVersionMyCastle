using Common.Entity.TaskPlannerService;
using System.Collections.Generic;
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

        public void Create(TaskEntity item)
        {
            db.Create(item);
        }

        public bool Delete(int id)
        {
            return db.Delete(id);
        }

        public IEnumerable<TaskEntity> GetAll()
        {
            return db.GetAll();
        }

        public IEnumerable<TaskEntity> GetByTaskCategoryId(int categoryId)
        {
            return db.GetByTaskCategoryId(categoryId);
        }

        public IEnumerable<TaskEntity> GetBySeverityId(int typeOfPurchaseId)
        {
            return db.GetBySeverityId(typeOfPurchaseId);
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
