using Timesheet_Expenses_API.Models;
using Timesheet_Expenses_API.Models.Object.Expense;

namespace Timesheet_Expenses_API.Repositories
{
    public interface IExepensesObjectsRep
    {
        public int GetUserId(string email);
        public List<Expense> GetExpenses();
        public bool CreateExpense(ExpObj expense);
    }

    public class ExepensesObjectsRep : IExepensesObjectsRep
    {
        private readonly _DbContext db;
        private int userId;
        private List<Expense> lstexpenses;

        public ExepensesObjectsRep(_DbContext _db)
        {
            db = _db;
        }
       
        //Busca o id user do email que recebe
        public int GetUserId(string email)
        {
            try
            {
                userId = db.users.Where(u => u.Email.Equals(email)).FirstOrDefault().User_Id;

                return userId;
            }
            catch
            {
                return 0;
            }
        }
        //busca todas as expenses do user 
        public List<Expense> GetExpenses()
        {
            try
            {
                lstexpenses = db.expenses.Where(e => e.User.User_Id.Equals(userId)).ToList();
                return lstexpenses;
            }
            catch
            {
                return new List<Expense>();

            }

        }
        //criar um despesa
        public bool CreateExpense(ExpObj newExpense)
        {
            try
            {
                var obj = new Expense
                {
                    Date = newExpense.Date,
                    TotalMoney = 0,
                    ExpenseType = db.expenseType.Find(db.expenseType.Where(et => et.Type.Equals(newExpense.ExpenseType)).FirstOrDefault().ExpenseType_Id),
                    ExpenseState = db.expenseState.Find(db.expenseState.Where(es => es.State.Equals(newExpense.ExpenseState)).FirstOrDefault().ExpenseState_Id),
                    Project = db.projects.Find(db.projects.Where(p => p.Project_Id.Equals(newExpense.project_id)).FirstOrDefault().Project_Id),
                    User = db.users.Find(db.users.Where(u => u.User_Id.Equals(newExpense.User)).FirstOrDefault().User_Id),
                    Qtd_Line = 0

                };
                db.expenses.Add(obj);
                db.SaveChanges();

                return false;
            }
            catch
            {
                return false;
            }

        }

        //Calcula o valor Total gasto
        public bool PutLine(int expenseid)
        {
            try
            {

                var TotalMoney = db.lines.Where(l => l.Expense.Equals(expenseid)).Sum(l => l.UnityPrice);

                var expense = db.expenses.Find(expenseid);
                expense.TotalMoney = TotalMoney;
                db.SaveChanges();

                return true;


            }
            catch
            {

                return false;
            }
        }
        //cria um line 
        public bool CreateLine(LinesObj line)
        {
            try 
            {
                var obj = new Line {

                    UnityPrice = line.UnityPrice,
                    Date = line.Date,
                    Expense = db.expenses.Find(line.Expense)
                
                
                };
                db.lines.Add(obj);
                db.SaveChanges();
            
            
            return true;
            }
            catch {
                return false;
            }
        
        
        }
    }
}
