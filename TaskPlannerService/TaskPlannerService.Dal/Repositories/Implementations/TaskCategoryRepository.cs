using Common.Entity.TaskPlannerService;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TaskPlannerService.Dal.Repositories.Interfaces;

namespace TaskPlannerService.Dal.Repositories.Implementations
{
    public class TaskCategoryRepository : ITaskCategoryRepository
    {
        private readonly IContext db;

        public TaskCategoryRepository(IContext db)
        {
            this.db = db;
        }

        public void Create(TaskCategory item)
        {
            var parameters = new List<SqlParameter>
            {
                db.CreateParameter("@Name", item.Name, DbType.String),
                db.CreateParameter("@IsOn", item.IsOn, DbType.Boolean),
                db.CreateParameter("@Color", item.Color, DbType.String),
                db.CreateParameter("@ImagePath", item.ImagePath, DbType.String),
                db.CreateParameter("@UserId", item.UserId, DbType.Int32)
            };

            try
            {
                db.Insert("CreateTaskCategory", CommandType.StoredProcedure, parameters.ToArray());
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
                db.Delete("DeleteTaskCategory", CommandType.StoredProcedure, parameters.ToArray());
            }
            catch
            {
                return false;
            }

            return true;
        }

        public IEnumerable<TaskCategory> GetAll()
        {
            var taskCategoryDataTable = db.GetDataTable("GetTaskCategories", CommandType.StoredProcedure);
            return GetTaskCategoriesFromRows(taskCategoryDataTable.Rows);
        }

        private List<TaskCategory> GetTaskCategoriesFromRows(DataRowCollection rows)
        {
            var categories = new List<TaskCategory>();

            foreach (DataRow row in rows)
            {
                var category = new TaskCategory
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    Color = row["Color"].ToString(),
                    IsOn = Convert.ToBoolean(row["IsOn"]),
                    ImagePath = row["ImagePath"].ToString(),
                    UserId = Convert.ToInt32(row["UserId"])
                };
                categories.Add(category);
            }

            return categories;
        }

        public TaskCategory GetItemById(int id)
        {
            var parameters = new List<SqlParameter>
            {
                db.CreateParameter("@Id", id, DbType.Int32)
            };

            var taskCategoryDataTable = db.GetDataTable("GetTaskCategoryById", CommandType.StoredProcedure, parameters.ToArray());

            var categories = GetTaskCategoriesFromRows(taskCategoryDataTable.Rows);

            return categories[0];
        }

        public void Update(TaskCategory item)
        {
            var parameters = new List<SqlParameter>
            {
                db.CreateParameter("@Id", item.Id, DbType.Int32),
                db.CreateParameter("@Name", item.Name, DbType.String),
                db.CreateParameter("@IsOn", item.IsOn, DbType.Boolean),
                db.CreateParameter("@Color", item.Color, DbType.String),
                db.CreateParameter("@ImagePath", item.ImagePath, DbType.String),
                db.CreateParameter("@UserId", item.UserId, DbType.Int32)
            };

            db.Update("UpdateTaskCategory", CommandType.StoredProcedure, parameters.ToArray());
        }
    }
}
