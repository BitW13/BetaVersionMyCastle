using Common.Entity.FileService;
using Common.Interfaces;
using FileSharingService.Dal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FileSharingService.Dal.Repositories.Implementations
{
    public class FileCategoryRepository : IFileCategoryRepository
    {
        private readonly IContext db;

        public FileCategoryRepository(IContext db)
        {
            this.db = db;
        }

        public void Create(FileCategory item)
        {
            var parameters = new List<SqlParameter>
            {
                db.CreateParameter("@Name", item.Name, DbType.String)
            };

            db.Insert("CreateFileCategory", CommandType.StoredProcedure, parameters.ToArray());
        }

        public bool Delete(int id)
        {
            var parameters = new List<SqlParameter>
            {
                db.CreateParameter("@Id", id, DbType.Int32)
            };

            try
            {
                db.Delete("DeleteFileCategory", CommandType.StoredProcedure, parameters.ToArray());
            }
            catch
            {
                return false;
            }

            return true;
        }

        public IEnumerable<FileCategory> GetAll()
        {
            var categoryDataTable = db.GetDataTable("GetCategories", CommandType.StoredProcedure);
            var categories = new List<FileCategory>();
            foreach (DataRow row in categoryDataTable.Rows)
            {
                var category = new FileCategory
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString()
                };
                categories.Add(category);
            }
            return categories;
        }

        public FileCategory GetItemById(int id)
        {
            var parameters = new List<SqlParameter>
            {
                db.CreateParameter("@Id", id, DbType.Int32)
            };

            var categoriesDataTable = db.GetDataTable("GetFileCategoryById", CommandType.StoredProcedure, parameters.ToArray());

            var categories = new List<FileCategory>();
            foreach (DataRow row in categoriesDataTable.Rows)
            {
                var category = new FileCategory
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString()
                };
                categories.Add(category);
            }
            return categories[0];
        }

        public FileCategory GetItemByName(FileCategory item)
        {
            var parameters = new List<SqlParameter>
            {
                db.CreateParameter("@Name", item.Name, DbType.String)
            };

            var categoriesDataTable = db.GetDataTable("GetFileCategoryByName", CommandType.StoredProcedure, parameters.ToArray());

            var categories = new List<FileCategory>();
            foreach (DataRow row in categoriesDataTable.Rows)
            {
                var category = new FileCategory
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString()
                };
                categories.Add(category);
            }
            if (categories.Count != 0)
            {
                return categories[0];
            }
            else
            {
                return null;
            }
        }

        public void Update(FileCategory item)
        {
            var parameters = new List<SqlParameter>
            {
                db.CreateParameter("@Id", item.Id, DbType.Int32),
                db.CreateParameter("@Name", item.Name, DbType.String)
            };

            db.Update("UpdateFileCategory", CommandType.StoredProcedure, parameters.ToArray());
        }
    }
}
