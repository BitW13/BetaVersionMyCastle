using Common.Entity.TaskPlannerService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TaskPlannerService.Dal.Contexts;
using TaskPlannerService.Dal.Repositories.Interfaces;

namespace TaskPlannerService.Dal.Repositories.Implementations
{
    public class SeverityRepository : ISeverityRepository
    {
        private readonly TaskPlannerServiceContext db;

        public SeverityRepository(TaskPlannerServiceContext db)
        {
            this.db = db;
        }

        public void Create(Severity item)
        {
            if (item != null)
            {
                try
                {
                    db.Severities.Add(item);

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
            Severity item = db.Severities.Find(id);

            if (item != null)
            {
                try
                {
                    db.Severities.Remove(item);

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

        public IEnumerable<Severity> GetAll()
        {
            return db.Severities;
        }

        public Severity GetItemById(int id)
        {
            return db.Severities.Find(id);
        }

        public void Update(Severity item)
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
