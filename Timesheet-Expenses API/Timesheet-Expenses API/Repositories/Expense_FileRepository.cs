using Timesheet_Expenses_API.Models;
using Timesheet_Expenses_API.Models.Entities.Expense_File;

namespace Timesheet_Expenses_API.Repositories
{
    public interface IExpense_FileRepository
    {
        public bool Create(PostExpense_File expense_File);
        public Expense_File Read(int eid, int fid);
        public bool Update(PutExpense_File expense_File);
        public bool Delete(int eid, int fid);
    }

    public class Expense_FileRepository:IExpense_FileRepository
    {
        private readonly _DbContext db;

        public Expense_FileRepository(_DbContext _db)
        {
            db = _db;
        }

        public bool Create(PostExpense_File expense_File)
        {
            try
            {
                var expense_File_db = new Expense_File()
                {
                    FileContent = expense_File.FileContent,
                    Expenses = expense_File.Expenses
                };
                db.expenses_files.Add(expense_File_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Expense_File Read(int eid, int fid)
        {
            try
            {
                var expense_File_db = db.expenses_files.Find(eid, fid);

                return expense_File_db;
            }
            catch
            {
                return new Expense_File();
            }
        }

        public bool Update(PutExpense_File expense_File)
        {
            try
            {
                var expense_File_db = db.expenses_files.Find(expense_File.ExpensesId, expense_File.FileContentId);
                expense_File_db.FileContent = expense_File.FileContent;
                expense_File_db.Expenses = expense_File.Expenses;
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int eid, int fid)
        {
            try
            {
                var expense_File_db = db.expenses_files.Find(eid, fid);
                db.expenses_files.Remove(expense_File_db);
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
