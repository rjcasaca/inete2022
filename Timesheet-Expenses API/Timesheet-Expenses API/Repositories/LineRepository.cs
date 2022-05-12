using Timesheet_Expenses_API.Models;
using Timesheet_Expenses_API.Models.Entities.Line;

namespace Timesheet_Expenses_API.Repositories
{
    public interface ILineRepository
    {
        public bool Create(PostLine line);
        public Line Read(int id);
        public bool Update(PutLine line);
        public bool Delete(int id);
    }

    public class LineRepository:ILineRepository
    {
        private readonly _DbContext db;

        public LineRepository(_DbContext _db)
        {
            db = _db;
        }

        public bool Create(PostLine line)
        {
            try
            {
                var line_db = new Line()
                {
                    UnityPrice = line.UnityPrice,
                    Date = line.Date,
                    Expenses = line.Expenses
                };
                db.lines.Add(line_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Line Read(int id)
        {
            try
            {
                var line_db = db.lines.Find(id);

                return line_db;
            }
            catch
            {
                return new Line();
            }
        }

        public bool Update(PutLine line)
        {
            try
            {
                var line_db = db.lines.Find(line.Cod_Line);
                line_db.UnityPrice = line.UnityPrice;
                line_db.Date = line.Date;
                line_db.Expenses = line.Expenses;
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
                var line_db = db.lines.Find(id);
                db.lines.Remove(line_db);
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
