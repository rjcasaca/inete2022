using Timesheet_Expenses_API.Models;
using Timesheet_Expenses_API.Models.Entities.Expense;

namespace Timesheet_Expenses_API.Repositories
{
    public interface IExpenseRepository
    {
        public bool Create(PostExpense expense);
        public Expense Read(int id);
        public bool Update(PutExpense expense);
        public bool Delete(int id);
    }

    public class ExpenseRepository:IExpenseRepository
    {
        private readonly _DbContext db;

        public ExpenseRepository(_DbContext _db)
        {
            db = _db;
        }

        public bool Create(PostExpense expense)
        {
            try
            {
                var expense_db = new Expense()
                {
                    Project = expense.Project,
                    User = expense.User,
                    Date = expense.Date,
                    ExpenseType = expense.ExpenseType,
                    ExpenseState = expense.ExpenseState,
                    TotalMoney = expense.TotalMoney
                };
                db.expenses.Add(expense_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Expense Read(int id)
        {
            try
            {
                var expense_db = db.expenses.Find(id);

                return expense_db;
            }
            catch
            {
                return new Expense();
            }
        }

        public bool Update(PutExpense expense)
        {
            try
            {
                var expense_db = db.expenses.Find(expense.Expense_Id);
                expense_db.Project = expense.Project;
                expense_db.User = expense.User;
                expense_db.Date = expense.Date;
                expense_db.ExpenseType = expense.ExpenseType;
                expense_db.ExpenseState = expense.ExpenseState;
                expense_db.TotalMoney = expense.TotalMoney;
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
                var expense_db = db.expenses.Find(id);
                db.expenses.Remove(expense_db);
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
