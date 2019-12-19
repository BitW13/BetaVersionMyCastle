using Common.Entity.TaskPlannerService;
using System.Collections.Generic;
using System.Linq;
using TaskPlannerService.Bll.BusinessLogic.Interfaces;

namespace TaskPlannerService.PL.TaskCards
{
    public class TaskCardPresenter : ITaskCardPresenter
    {
        private readonly IBusinessLogic db;

        public TaskCardPresenter(IBusinessLogic db)
        {
            this.db = db;
        }

        public TaskCard Create(TaskEntity item)
        {
            db.Tasks.Create(item);

            var tasks = db.Tasks.GetAll().ToList();

            var task = tasks[tasks.Count - 1];

            return GetItemById(task.Id);
        }

        public bool Delete(int id)
        {
            TaskEntity item = db.Tasks.GetItemById(id);

            if (item == null)
            {
                return false;
            }

            return db.Tasks.Delete(id);
        }

        public IEnumerable<TaskCard> GetAll()
        {
            IEnumerable<TaskEntity> items = db.Tasks.GetAll();

            List<TaskCard> cards = new List<TaskCard>();

            foreach (var item in items)
            {
                TaskCard card = CollectCard(item);

                if (card != null)
                {
                    cards.Add(card);
                }
            }

            return cards;
        }

        public TaskCard GetItemById(int id)
        {
            TaskEntity item = db.Tasks.GetItemById(id);

            if (item == null)
            {
                return null;
            }

            TaskCard card = CollectCard(item);

            return card;
        }

        public TaskCard Update(TaskEntity item)
        {
            db.Tasks.Update(item);

            return GetItemById(item.Id);
        }

        private TaskCard CollectCard(TaskEntity item)
        {
            if (item != null)
            {
                TaskCategory category = db.Categories.GetItemById(item.TaskCategoryId);

                Severity severity = db.Severities.GetItemById(item.SeverityId);

                return new TaskCard
                {
                    Task = item,
                    TaskCategory = category,
                    Severity = severity
                };
            }

            return null;
        }
    }
}
