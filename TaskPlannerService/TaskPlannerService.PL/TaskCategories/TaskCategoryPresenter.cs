using Common.Entity.TaskPlannerService;
using System.Collections.Generic;
using System.Linq;
using TaskPlannerService.Bll.BusinessLogic.Interfaces;

namespace TaskPlannerService.PL.TaskCategories
{
    public class TaskCategoryPresenter : ITaskCategoryPresenter
    {
        private readonly IBusinessLogic db;

        public TaskCategoryPresenter(IBusinessLogic db)
        {
            this.db = db;
        }

        public TaskCategory Create(TaskCategory item)
        {
            db.Categories.Create(item);

            var categories = db.Categories.GetAll().ToList();

            return categories[categories.Count - 1];
        }

        public bool Delete(int id)
        {
            TaskCategory item = db.Categories.GetItemById(id);

            if (item == null)
            {
                return false;
            }

            return db.Categories.Delete(id);
        }

        public IEnumerable<TaskCategory> GetAll()
        {
            return db.Categories.GetAll();
        }

        public TaskCategory GetItemById(int id)
        {
            return db.Categories.GetItemById(id);
        }

        public TaskCategory Update(TaskCategory item)
        {
            db.Categories.Update(item);

            return item;
        }
    }
}
