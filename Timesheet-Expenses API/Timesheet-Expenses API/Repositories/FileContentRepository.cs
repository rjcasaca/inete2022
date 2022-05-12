using Timesheet_Expenses_API.Models;
using Timesheet_Expenses_API.Models.Entities.FileContent;

namespace Timesheet_Expenses_API.Repositories
{
    public interface IFileContentRepository
    {
        public bool Create(PostFileContent fileContent);
        public FileContent Read(int id);
        public bool Update(PutFileContent fileContent);
        public bool Delete(int id);
    }

    public class FileContentRepository:IFileContentRepository
    {
        private readonly _DbContext db;

        public FileContentRepository(_DbContext _db)
        {
            db = _db;
        }

        public bool Create(PostFileContent fileContent)
        {
            try
            {
                var fileContent_db = new FileContent()
                {
                    Name = fileContent.Name,
                    FileId = fileContent.FileId,
                    FileContentType = fileContent.FileContentType
                };
                db.fileContents.Add(fileContent_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public FileContent Read(int id)
        {
            try
            {
                var fileContent_db = db.fileContents.Find(id);

                return fileContent_db;
            }
            catch
            {
                return new FileContent();
            }
        }

        public bool Update(PutFileContent fileContent)
        {
            try
            {
                var fileContent_db = db.fileContents.Find(fileContent.FileContent_Id);
                fileContent_db.Name = fileContent.Name;
                fileContent_db.FileContentType = fileContent.FileContentType;
                fileContent_db.FileId = fileContent.FileId;
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var fileContent_db = db.fileContents.Find(id);
                db.fileContents.Remove(fileContent_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
