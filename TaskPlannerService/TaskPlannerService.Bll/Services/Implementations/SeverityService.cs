using Common.Entity.TaskPlannerService;
using System.Collections.Generic;
using System.Linq;
using TaskPlannerService.Bll.Services.Interfaces;
using TaskPlannerService.Dal.Repositories.Interfaces;

namespace TaskPlannerService.Bll.Services.Implementations
{
    public class SeverityService : ISeverityService
    {
        private readonly ISeverityRepository db;

        public SeverityService(ISeverityRepository db)
        {
            this.db = db;
        }

        public Severity Create(Severity item)
        {
            db.Create(item);

            var items = GetAll().ToList();

            return items[items.Count - 1];
        }

        public bool Delete(int id)
        {
            return db.Delete(id);
        }

        public IEnumerable<Severity> GetAll()
        {
            return db.GetAll();
        }

        public Severity GetItemById(int id)
        {
            return db.GetItemById(id);
        }

        public void Update(Severity item)
        {
            db.Update(item);
        }
    }
}
