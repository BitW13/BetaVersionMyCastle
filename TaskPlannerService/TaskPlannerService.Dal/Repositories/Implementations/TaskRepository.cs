using Common.Entity.TaskPlannerService;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TaskPlannerService.Dal.Repositories.Interfaces;

namespace TaskPlannerService.Dal.Repositories.Implementations
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IContext db;

        public TaskRepository(IContext db)
        {
            this.db = db;
        }
        public void Create(TaskEntity item)
        {

            var parameters = new List<SqlParameter>
            {
                db.CreateParameter("@Name", item.Name, DbType.String),
                db.CreateParameter("@Description", item.Description, DbType.String),
                db.CreateParameter("@TaskCategoryId", item.TaskCategoryId, DbType.Int32),
                db.CreateParameter("@SeverityId", item.SeverityId, DbType.Int32),
                db.CreateParameter("@PlannerDateId", item.PlannerDateId, DbType.Int32),
                db.CreateParameter("@IsDone", item.IsDone, DbType.Boolean),
                db.CreateParameter("@UserId", item.UserId, DbType.Int32)
            };

            try
            {
                db.Insert("CreateTask", CommandType.StoredProcedure, parameters.ToArray());
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
                db.Delete("DeleteTask", CommandType.StoredProcedure, parameters.ToArray());
            }
            catch
            {
                return false;
            }

            return true;
        }

        public IEnumerable<TaskEntity> GetAll()
        {
            var taskDataTable = db.GetDataTable("GetTasks", CommandType.StoredProcedure);
            return GetTasksFromRows(taskDataTable.Rows);
        }

        private List<TaskEntity> GetTasksFromRows(DataRowCollection rows)
        {
            var tasks = new List<TaskEntity>();

            foreach (DataRow row in rows)
            {
                var task = new TaskEntity
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    Description = row["Description"].ToString(),
                    IsDone = Convert.ToBoolean(row["IsDone"]),
                    PlannerDateId = Convert.ToInt32(row["PlannerDateId"]),
                    TaskCategoryId = Convert.ToInt32(row["TaskCategoryId"]),
                    SeverityId = Convert.ToInt32(row["SeverityId"]),
                    UserId = Convert.ToInt32(row["UserId"])
                };
                tasks.Add(task);
            }

            return tasks;
        }

        public IEnumerable<TaskEntity> GetByTaskCategoryId(int categoryId)
        {
            var parameters = new List<SqlParameter>
            {
                db.CreateParameter("@CategoryId", categoryId, DbType.Int32)
            };

            var tasksDataTable = db.GetDataTable("GetTasksByCategoryId", CommandType.StoredProcedure, parameters.ToArray());

            return GetTasksFromRows(tasksDataTable.Rows);
        }

        public IEnumerable<TaskEntity> GetBySeverityId(int severityId)
        {
            var parameters = new List<SqlParameter>
            {
                db.CreateParameter("@SeverityId", severityId, DbType.Int32)
            };

            var tasksDataTable = db.GetDataTable("GetTasksBySeverityId", CommandType.StoredProcedure, parameters.ToArray());

            return GetTasksFromRows(tasksDataTable.Rows);
        }

        public TaskEntity GetItemById(int id)
        {
            var parameters = new List<SqlParameter>
            {
                db.CreateParameter("@Id", id, DbType.Int32)
            };

            var tasksDataTable = db.GetDataTable("GetTaskById", CommandType.StoredProcedure, parameters.ToArray());

            var tasks = GetTasksFromRows(tasksDataTable.Rows);

            return tasks[0];
        }

        public void Update(TaskEntity item)
        {
            var parameters = new List<SqlParameter>
            {
                db.CreateParameter("@Id", item.Id, DbType.Int32),
                db.CreateParameter("@Name", item.Name, DbType.String),
                db.CreateParameter("@Description", item.Description, DbType.String),
                db.CreateParameter("@TaskCategoryId", item.TaskCategoryId, DbType.Int32),
                db.CreateParameter("@SeverityId", item.SeverityId, DbType.Int32),
                db.CreateParameter("@PlannerDateId", item.PlannerDateId, DbType.Int32),
                db.CreateParameter("@IsDone", item.IsDone, DbType.Boolean),
                db.CreateParameter("@UserId", item.UserId, DbType.Int32)
            };

            db.Update("UpdateTask", CommandType.StoredProcedure, parameters.ToArray());
        }
    }
}
