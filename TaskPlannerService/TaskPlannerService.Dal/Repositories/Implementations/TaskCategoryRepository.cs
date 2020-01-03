using Common.Entity.TaskPlannerService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TaskPlannerService.Dal.Contexts;
using TaskPlannerService.Dal.Repositories.Interfaces;

namespace TaskPlannerService.Dal.Repositories.Implementations
{
    public class TaskCategoryRepository : ITaskCategoryRepository
    {
        private readonly TaskPlannerServiceContext db;

        public TaskCategoryRepository(TaskPlannerServiceContext db)
        {
            this.db = db;
        }

        public void Create(TaskCategory item)
        {
            if (item != null)
            {
                try
                {
                    db.Categories.Add(item);

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
            TaskCategory item = db.Categories.Find(id);

            if (item != null)
            {
                try
                {
                    db.Categories.Remove(item);

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

        public IEnumerable<TaskCategory> GetAll()
        {
            return db.Categories;
        }

        public TaskCategory GetItemById(int id)
        {
            return db.Categories.Find(id);
        }

        public void Update(TaskCategory item)
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
