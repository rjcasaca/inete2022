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
                    ExpenseState = expense.ExpenseState,
                    TotalMoney = expense.TotalMoney,
                    Qtd_Line = expense.Qtd_Line
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
                var expense_db = db.expenses.Find(expense.Expenses_Id);
                expense_db.Project = expense.Project;
                expense_db.User = expense.User;
                expense_db.Date = expense.Date;
                expense_db.ExpenseState = expense.ExpenseState;
                expense_db.TotalMoney = expense.TotalMoney;
                expense_db.Qtd_Line = expense.Qtd_Line;
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
