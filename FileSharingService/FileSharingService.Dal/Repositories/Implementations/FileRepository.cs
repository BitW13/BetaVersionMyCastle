using Common.Entity.FileService;
using Common.Interfaces;
using FileSharingService.Dal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace FileSharingService.Dal.Repositories.Implementations
{
    public class FileRepository : IFileRepository
    {
        private readonly IContext db;

        public FileRepository(IContext db)
        {
            this.db = db;
        }

        public void Create(File item)
        {
            var parameters = new List<SqlParameter>
            {
                db.CreateParameter("@Name", item.Name, DbType.String),
                db.CreateParameter("@Size", item.Size, DbType.Double),
                db.CreateParameter("@Description", item.Description, DbType.String),
                db.CreateParameter("@CategoryId", item.CategoryId, DbType.Int32),
                db.CreateParameter("@DownloadDate", item.DownloadDate, DbType.String),
                db.CreateParameter("@UserId", item.UserId, DbType.Int32),
                db.CreateParameter("@FileAccessId", item.FileAccessId, DbType.Int32),
                db.CreateParameter("@FileUrlId", item.FileUrlId, DbType.Int32)
            };

            db.Insert("CreateFile", CommandType.StoredProcedure, parameters.ToArray());
        }

        public bool Delete(int id)
        {
            var parameters = new List<SqlParameter>
            {
                db.CreateParameter("@Id", id, DbType.Int32)
            };

            try
            {
                db.Delete("DeleteFile", CommandType.StoredProcedure, parameters.ToArray());
            }
            catch
            {
                return false;
            }

            return true;
        }

        public FileCard Get(int id)
        {
            var parameters = new List<SqlParameter>
            {
                db.CreateParameter("@Id", id, DbType.Int32)
            };

            var filesDataTable = db.GetDataTable("GetFileCardById", CommandType.StoredProcedure, parameters.ToArray());

            var files = GetFileCardsFromRows(filesDataTable.Rows).ToList();

            return files[0];
        }

        public IEnumerable<File> GetAll()
        {
            var fileDataTable = db.GetDataTable("GetFiles", CommandType.StoredProcedure);
            return GetFilesFromRows(fileDataTable.Rows);
        }

        public IEnumerable<FileCard> GetFileCards()
        {
            var fileDataTable = db.GetDataTable("GetFileCards", CommandType.StoredProcedure);
            return GetFileCardsFromRows(fileDataTable.Rows);
        }

        private IEnumerable<FileCard> GetFileCardsFromRows(DataRowCollection rows)
        {
            var fileCards = new List<FileCard>();
            foreach (DataRow row in rows)
            {
                var fileCard = new FileCard
                {
                    File = new File
                    {
                        Id = Convert.ToInt32(row["FileId"]),
                        Name = row["FileName"].ToString(),
                        Size = Convert.ToDouble(row["Size"]),
                        Description = row["Description"].ToString(),
                        CategoryId = Convert.ToInt32(row["FileCategoryId"]),
                        FileUrlId = Convert.ToInt32(row["FileUrlId"]),
                        DownloadDate = Convert.ToDateTime(row["DownloadDate"]),
                        FileAccessId = Convert.ToInt32(row["FileAccessId"]),
                        UserId = Convert.ToInt32(row["UserId"])
                    },
                    FileAccess = new FileAccess
                    {
                        Id = Convert.ToInt32(row["FileAccessId"]),
                        Name = row["FileAccessName"].ToString()
                    },
                    FileCategory = new FileCategory
                    {
                        Id = Convert.ToInt32(row["FileCategoryId"]),
                        Name = row["FileCategoryName"].ToString()
                    },
                    FileUrl = new FileUrl
                    {
                        Id = Convert.ToInt32(row["FileUrlId"]),
                        Url = row["FileUrlName"].ToString()
                    }
                };
                fileCards.Add(fileCard);
            }
            return fileCards;
        }

        private IEnumerable<File> GetFilesFromRows(DataRowCollection rows)
        {
            var files = new List<File>();
            foreach (DataRow row in rows)
            {
                var file = new File
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    Size = Convert.ToDouble(row["Size"]),
                    Description = row["Description"].ToString(),
                    CategoryId = Convert.ToInt32(row["CategoryId"]),
                    FileUrlId = Convert.ToInt32(row["FileUrlId"]),
                    DownloadDate = Convert.ToDateTime(row["DownloadDate"]),
                    FileAccessId = Convert.ToInt32(row["FileAccessId"]),
                    UserId = Convert.ToInt32(row["UserId"])
                };
                files.Add(file);
            }

            return files;
        }

        public File GetItemById(int id)
        {
            var parameters = new List<SqlParameter>
            {
                db.CreateParameter("@Id", id, DbType.Int32)
            };

            var filesDataTable = db.GetDataTable("GetFileById", CommandType.StoredProcedure, parameters.ToArray());

            var files = GetFilesFromRows(filesDataTable.Rows).ToList();

            return files[0];
        }

        public void Update(File item)
        {
            var parameters = new List<SqlParameter>
            {
                db.CreateParameter("@Id", item.Id, DbType.Int32),
                db.CreateParameter("@Name", item.Name, DbType.String),
                db.CreateParameter("@Size", item.Size, DbType.Double),
                db.CreateParameter("@Description", item.Description, DbType.String),
                db.CreateParameter("@CategoryId", item.CategoryId, DbType.Int32),
                db.CreateParameter("@DownloadDate", item.DownloadDate, DbType.String),
                db.CreateParameter("@UserId", item.UserId, DbType.Int32),
                db.CreateParameter("@FileAccessId", item.FileAccessId, DbType.Int32),
                db.CreateParameter("@FileUrlId", item.FileUrlId, DbType.Int32)
            };

            db.Update("UpdateFile", CommandType.StoredProcedure, parameters.ToArray());
        }
    }
}
