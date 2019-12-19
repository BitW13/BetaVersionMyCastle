using Common.Entity.TaskPlannerService;
using System.Collections.Generic;
using System.Linq;
using TaskPlannerService.Bll.BusinessLogic.Interfaces;

namespace TaskPlannerService.PL.Severities
{
    public class SeverityPresenter : ISeverityPresenter
    {
        private readonly IBusinessLogic db;

        public SeverityPresenter(IBusinessLogic db)
        {
            this.db = db;
        }

        public Severity Create(Severity item)
        {
            db.Severities.Create(item);

            List<Severity> severities = db.Severities.GetAll().ToList();

            return severities[severities.Count - 1];
        }

        public bool Delete(int id)
        {
            return db.Severities.Delete(id);
        }

        public IEnumerable<Severity> GetAll()
        {
            return db.Severities.GetAll();
        }

        public Severity GetItemById(int id)
        {
            return db.Severities.GetItemById(id);
        }

        public Severity Update(Severity item)
        {
            db.Severities.Update(item);

            return item;
        }
    }
}
