using Timesheet_Expenses_API.Models;
using Timesheet_Expenses_API.Models.Entities.ExpenseState;

namespace Timesheet_Expenses_API.Repositories
{
    public interface IExpenseStateRepository
    {
        public bool Create(PostExpenseState expenseState);
        public ExpenseState Read(int id);
        public bool Update(PutExpenseState expenseState);
        public bool Delete(int id);
    }

    public class ExpenseStateRepository:IExpenseStateRepository
    {
        private readonly _DbContext db;

        public ExpenseStateRepository(_DbContext _db)
        {
            db = _db;
        }

        public bool Create(PostExpenseState expenseState)
        {
            try
            {
                var expenseState_db = new ExpenseState()
                {
                    State = expenseState.State
                };
                db.expenseState.Add(expenseState_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public ExpenseState Read(int id)
        {
            try
            {
                var expenseState_db = db.expenseState.Find(id);

                return expenseState_db;
            }
            catch
            {
                return new ExpenseState();
            }
        }

        public bool Update(PutExpenseState expenseState)
        {
            try
            {
                var expenseState_db = db.expenseState.Find(expenseState.ExpenseState_Id);
                expenseState_db.State = expenseState.State;
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
                var expenseState_db = db.expenseState.Find(id);
                db.expenseState.Remove(expenseState_db);
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
