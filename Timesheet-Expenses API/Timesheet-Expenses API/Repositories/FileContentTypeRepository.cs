using Timesheet_Expenses_API.Models;
using Timesheet_Expenses_API.Models.Entities.FileContentType;

namespace Timesheet_Expenses_API.Repositories
{
    public interface IFileContentTypeRepository
    {
        public bool Create(PostFileContentType fileContentType);
        public FileContentType Read(int id);
        public bool Update(PutFileContentType fileContentType);
        public bool Delete(int id);
    }

    public class FileContentTypeRepository:IFileContentTypeRepository
    {
        private readonly _DbContext db;

        public FileContentTypeRepository(_DbContext _db)
        {
            db = _db;
        }

        public bool Create(PostFileContentType fileContentType)
        {
            try
            {
                var fileContentType_db = new FileContentType()
                {
                    Type = fileContentType.Type
                };
                db.fileContType.Add(fileContentType_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public FileContentType Read(int id)
        {
            try
            {
                var fileContentType_db = db.fileContType.Find(id);

                return fileContentType_db;
            }
            catch
            {
                return new FileContentType();
            }
        }

        public bool Update(PutFileContentType fileContentType)
        {
            try
            {
                var fileContentType_db = db.fileContType.Find(fileContentType.FileContentType_Id);
                fileContentType_db.Type = fileContentType.Type;
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
                var fileContentType_db = db.fileContType.Find(id);
                db.fileContType.Remove(fileContentType_db);
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
