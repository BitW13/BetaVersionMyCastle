using Common.Entity.TaskPlannerService;
using System.Collections.Generic;
using TaskPlannerService.Bll.Services.Interfaces;
using TaskPlannerService.Dal.Repositories.Interfaces;

namespace TaskPlannerService.Bll.Services.Implementations
{
    public class TaskCategoryService : ITaskCategoryService
    {
        private readonly ITaskCategoryRepository db;

        public TaskCategoryService(ITaskCategoryRepository db)
        {
            this.db = db;
        }

        public void Create(TaskCategory item)
        {
            db.Create(item);
        }

        public bool Delete(int id)
        {
            return db.Delete(id);
        }

        public IEnumerable<TaskCategory> GetAll()
        {
            return db.GetAll();
        }

        public TaskCategory GetItemById(int id)
        {
            return db.GetItemById(id);
        }

        public void Update(TaskCategory item)
        {
            db.Update(item);
        }
    }
}
