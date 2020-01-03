using Common.Entity.TaskPlannerService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TaskPlannerService.Dal.Contexts;
using TaskPlannerService.Dal.Repositories.Interfaces;

namespace TaskPlannerService.Dal.Repositories.Implementations
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskPlannerServiceContext db;

        public TaskRepository(TaskPlannerServiceContext db)
        {
            this.db = db;
        }
        public void Create(TaskEntity item)
        {
            if (item != null)
            {
                try
                {
                    db.Tasks.Add(item);

                    db.SaveChanges();

                    return;
                }
                catch (Exception ex)
                {
                    return;
                }
            }

            return;
        }

        public bool Delete(int id)
        {
            TaskEntity item = db.Tasks.Find(id);

            if (item != null)
            {
                try
                {
                    db.Tasks.Remove(item);

                    db.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            return false;
        }

        public IEnumerable<TaskEntity> GetAll()
        {
            return db.Tasks;
        }

        public IEnumerable<TaskEntity> GetByTaskCategoryId(int categoryId)
        {
            var items = (GetAll()) as List<TaskEntity>;

            return items.FindAll(item => item.TaskCategoryId == categoryId);
        }

        public IEnumerable<TaskEntity> GetBySeverityId(int severityId)
        {
            var items = (GetAll()) as List<TaskEntity>;

            return items.FindAll(item => item.SeverityId == severityId);
        }

        public TaskEntity GetItemById(int id)
        {
            return db.Tasks.Find(id);
        }

        public void Update(TaskEntity item)
        {
            if (item != null)
            {
                try
                {
                    db.Entry(item).State = EntityState.Modified;

                    db.SaveChanges();

                    return;
                }
                catch (Exception ex)
                {
                    return;
                }
            }

            return;
        }
    }
}
