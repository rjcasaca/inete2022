using Timesheet_Expenses_API.Models;
using Timesheet_Expenses_API.Models.Entities.ExpenseType;

namespace Timesheet_Expenses_API.Repositories
{
    public interface IExpenseTypeRepository
    {
        public bool Create(PostExpenseType expenseType);
        public ExpenseType Read(int id);
        public bool Update(PutExpenseType expenseType);
        public bool Delete(int id);
    }

    public class ExpenseTypeRepository:IExpenseTypeRepository
    {
        private readonly _DbContext db;

        public ExpenseTypeRepository(_DbContext _db)
        {
            db = _db;
        }

        public bool Create(PostExpenseType expenseType)
        {
            try
            {
                var expenseType_db = new ExpenseType()
                {
                    Type = expenseType.Type
                };
                db.expenseType.Add(expenseType_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public ExpenseType Read(int id)
        {
            try
            {
                var expenseType_db = db.expenseType.Find(id);

                return expenseType_db;
            }
            catch
            {
                return new ExpenseType();
            }
        }

        public bool Update(PutExpenseType expenseType)
        {
            try
            {
                var expenseType_db = db.expenseType.Find(expenseType.ExpenseType_Id);
                expenseType_db.Type = expenseType.Type;
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
                var expenseType_db = db.expenseType.Find(id);
                db.expenseType.Remove(expenseType_db);
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
