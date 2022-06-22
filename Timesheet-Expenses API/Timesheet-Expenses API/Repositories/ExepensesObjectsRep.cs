using Timesheet_Expenses_API.Models;
using Timesheet_Expenses_API.Models.Object.Expense;

namespace Timesheet_Expenses_API.Repositories
{
    public interface IExepensesObjectsRep
    {
        public int GetUserId(string email);
        public List<Expense> GetExpenses(int userId);
        public bool CreateExpense(DateTime data, string ExpenseType, string ExpenseStateId, string email, string ProjectId, decimal TotalMoney, string nameExpense);
        public bool PutLine(int expenseid);
        public bool CreateLine(decimal UnityPrice, DateTime Date, string discription, decimal period, int linecity, int lineType, int ExpenseID);
        public bool CreateBill(byte[] image, string Name, int FileContentTypeId, int expenseId, int FileID, string Type, int fileContentId);
        public decimal ValueAproved(int userid);
        public List<ExpenseType> GetTypeList(int user);
        public decimal ValuePending(int userid);
        public decimal ValueDenied(int userid);
        public decimal ValueTotal(int userid);
        public bool UpdateState(int expenseid, string newstate);

    }

    public class ExepensesObjectsRep : IExepensesObjectsRep
    {
        private readonly _DbContext db;

        public ExepensesObjectsRep(_DbContext _db)
        {
            db = _db;
        }

        //Busca o id user do email que recebe
        public int GetUserId(string email)
        {
            try
            {
                int userId = db.users.Where(u => u.Email.Equals(email)).FirstOrDefault().User_Id;

                return userId;
            }
            catch
            {
                return 0;
            }
        }
        //Busca Valor Aprovado
        public decimal ValueAproved(int userid)
        {
            try
            {
                decimal result = 0;
                List<Expense> lstexpenses = db.expenses.Where(e => e.UserId.Equals(userid)).ToList();
                foreach(Expense exp in lstexpenses) 
                {
                    if (exp.ExpenseStateId == 1) 
                    {
                        result += exp.TotalMoney;
                    
                    
                    }
                
                }
                return result ;
            }
            catch
            {
                return 0;
            }

        }
        //Busca Valor Pendente
        public decimal ValuePending(int userid)
        {
            try
            {
                decimal result = 0;
                List<Expense> lstexpenses = db.expenses.Where(e => e.UserId.Equals(userid)).ToList();
                foreach (Expense exp in lstexpenses)
                {
                    if (exp.ExpenseStateId == 3)
                    {
                        result += exp.TotalMoney;


                    }

                }
                return result;
            }
            catch
            {
                return 0;
            }

        }
        //Busca Valor Rejeitado
        public decimal ValueDenied(int userid)
        {
            try
            {
                decimal result = 0;
                List<Expense> lstexpenses = db.expenses.Where(e => e.UserId.Equals(userid)).ToList();
                foreach (Expense exp in lstexpenses)
                {
                    if (exp.ExpenseStateId == 2)
                    {
                        result += exp.TotalMoney;


                    }

                }
                return result;
            }
            catch
            {
                return 0;
            }

        }
        public decimal ValueTotal(int userid)
        {
            try
            {
                decimal result = 0;
                List<Expense> lstexpenses = db.expenses.Where(e => e.UserId.Equals(userid)).ToList();
                foreach (Expense exp in lstexpenses)
                {
                   
                    
                        result += exp.TotalMoney;


                    

                }
                return result;
            }
            catch
            {
                return 0;
            }

        }
        public List<ExpenseType> GetTypeList(int user)
        {

            try
            {
                List<ExpenseType> lstexpensestype = db.expenseType.ToList();
                return lstexpensestype;
            }
            catch
            {
                return new List<ExpenseType>();
            }


        }
        //busca todas as expenses do user 
        public List<Expense> GetExpenses(int userId)
        {
            try
            {
               List<Expense> lstexpenses = db.expenses.Where(e => e.UserId.Equals(userId)).ToList();
                return lstexpenses;
            }
            catch
            {
                return new List<Expense>();
            }
        }
        //criar um despesa
        public bool CreateExpense(DateTime data, string ExpenseType, string ExpenseStateId, string email, string ProjectId, decimal TotalMoney,string nameExpense)
        {
            try { 
           
                Expense obj = new Expense
                {
                    Date = data,
                    Expense_Name=nameExpense,
                    TotalMoney = TotalMoney,
                    ExpenseTypeId = db.expenseType.Where(e => e.Type.Equals(ExpenseType)).FirstOrDefault().ExpenseType_Id,
                    ExpenseStateId = db.expenseState.Where(es => es.State.Equals(ExpenseStateId)).FirstOrDefault().ExpenseState_Id,
                    UserId = GetUserId(email),
                    ProjectId = db.projects.Where(p => p.Name.Equals(ProjectId)).FirstOrDefault().Project_Id
                };
                db.expenses.Add(obj);
                db.SaveChanges();
                 
                return true;
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
                var TotalMoney = db.lines.Where(l => l.ExpenseId.Equals(expenseid)).Sum(l => l.UnityPrice);

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
        public bool UpdateState(int expenseid, string newstate)
        {
            try
            {
                var expense = db.expenses.Where(e => e.ExpenseStateId.Equals(expenseid)).FirstOrDefault();
                expense.ExpenseStateId = db.expenseState.Where(es => es.State.Equals(newstate)).FirstOrDefault().ExpenseState_Id;

                
               
                db.SaveChanges();

                return true;
            }
            catch
            {

                return false;
            }
        }
        //cria um line
        public bool CreateLine(decimal UnityPrice,DateTime Date,string discription, decimal period,int linecity,int lineType,int ExpenseID)
        {
            try
            { 
                var obj = new Line
                {

                UnityPrice=UnityPrice,
                Date=Date,
                Discription=discription,
                period=period,
                lineCIty=linecity,
                lineType=lineType,
                ExpenseId=ExpenseID
                    
            };
                db.lines.Add(obj);
                db.SaveChanges();
                
                PutLine(obj.ExpenseId);
                return true;
            }
            catch
            {
                return false;
            }
        }
       //Crianção da Fatura
        public bool CreateBill(byte[] image,string Name,int FileContentTypeId,int expenseId,int FileID, string Type,int fileContentId)
        {
            try
            {
                var file = new Models.File
                {

                    File_Id = FileID,
                    base64 = image
                };
                db.files.Add(file);
                db.SaveChanges();

                var fileContentType = new Models.FileContentType
                {
                    FileContentType_Id = FileContentTypeId,
                    Type = Type
                };
                db.fileContType.Add(fileContentType);
                db.SaveChanges();

                var FileContent = new Models.FileContent
                {
                    Name = Name,
                    FileId = FileID,
                    FileContentTypeId = FileContentTypeId
                };
                db.fileContents.Add(FileContent);
                db.SaveChanges();

                var ExpenseFileContent = new Models.Expense_File
                {
                    ExpenseId = expenseId,
                    FileContentId = fileContentId
                };
                db.expenses_files.Add(ExpenseFileContent);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(string Newstate,int idExpense)
        {
            try 
            {var expID= db.expenseState.Where(es => es.State.Equals(Newstate)).FirstOrDefault().ExpenseState_Id;
                var expense = db.expenses.Find(idExpense);
                expense.ExpenseStateId = expID;
                db.SaveChanges();
                return true;
            } 
            catch { return false; }

        }

    }
}
