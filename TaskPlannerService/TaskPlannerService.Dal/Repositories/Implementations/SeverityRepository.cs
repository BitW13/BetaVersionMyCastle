using Common.Entity.TaskPlannerService;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TaskPlannerService.Dal.Repositories.Interfaces;

namespace TaskPlannerService.Dal.Repositories.Implementations
{
    public class SeverityRepository : ISeverityRepository
    {
        private readonly IContext db;

        public SeverityRepository(IContext db)
        {
            this.db = db;
        }

        public void Create(Severity item)
        {
            var parameters = new List<SqlParameter>
            {
                db.CreateParameter("@Name", item.Name, DbType.String),
                db.CreateParameter("@UserId", item.UserId, DbType.Int32)
            };

            try
            {
                db.Insert("CreateSeverity", CommandType.StoredProcedure, parameters.ToArray());
            }
            catch
            {
                return;
            }
        }

        public bool Delete(int id)
        {
            var parameters = new List<SqlParameter>
            {
                db.CreateParameter("@Id", id, DbType.Int32)
            };

            try
            {
                db.Delete("DeleteSeverity", CommandType.StoredProcedure, parameters.ToArray());
            }
            catch
            {
                return false;
            }

            return true;
        }

        public IEnumerable<Severity> GetAll()
        {
            var severityDataTable = db.GetDataTable("GetSeverities", CommandType.StoredProcedure);
            return GetSeveritiesFromRows(severityDataTable.Rows);
        }

        private List<Severity> GetSeveritiesFromRows(DataRowCollection rows)
        {
            var severities = new List<Severity>();

            foreach (DataRow row in rows)
            {
                var severity = new Severity
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    UserId = Convert.ToInt32(row["UserId"])
                };
                severities.Add(severity);
            }

            return severities;
        }

        public Severity GetItemById(int id)
        {
            var parameters = new List<SqlParameter>
            {
                db.CreateParameter("@Id", id, DbType.Int32)
            };

            var severityDataTable = db.GetDataTable("GetSeverityById", CommandType.StoredProcedure, parameters.ToArray());

            var severities = GetSeveritiesFromRows(severityDataTable.Rows);

            return severities[0];
        }

        public void Update(Severity item)
        {
            var parameters = new List<SqlParameter>
            {
                db.CreateParameter("@Id", item.Id, DbType.Int32),
                db.CreateParameter("@Name", item.Name, DbType.String),
                db.CreateParameter("@UserId", item.UserId, DbType.Int32)
            };

            db.Update("UpdateSeverity", CommandType.StoredProcedure, parameters.ToArray());
        }
    }
}
