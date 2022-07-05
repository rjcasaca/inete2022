using Timesheet_Expenses_API.Models;
using Timesheet_Expenses_API.Models.Object.Expense;

namespace Timesheet_Expenses_API.Repositories
{
    public interface IExepensesObjectsRep
    {
        #region
        public int GetUserId(string email);
        public List<Expense> GetExpenses(int userId);
        public bool CreateExpense(string Month, int Year, string ExpenseStateId, string email, string ProjectId, decimal TotalMoney, string nameExpense);
        public bool PutLine(int expenseid);
        public bool CreateLine(decimal UnityPrice, DateTime Date, string discription, string linecity, string lineType, int ExpenseID);
        public bool CreateBill(string image, string Name, int expenseId, string Type);
        public decimal ValueAproved(int userid);
        public List<ExpenseType> GetTypeList(int user);
        public decimal ValuePending(int userid);
        public decimal ValueDenied(int userid);
        public decimal ValueTotal(int userid);
        public bool UpdateState(int expenseid, string newstate);
        public List<Line> GetLines(int expenseid);
        public bool DeleteLine(int LineId);
        public bool DeleteExpense(int expenseid);
        public List<LineType> GetLineType(int line);
        public List<LineCity> GetLinesCity(int user);
        public int GetExpenseId(int userid, string expensename);
        public Expense getExpense(int expenseID);
        public Line GetLine(string line, int expenseid);
        public bool verifyExpense(int expenseID);
        public int getLineId(int expenseId, string Type);
        public bool DeleteBill(string nameImage);
        #endregion
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

        //Delete Line
        public bool DeleteLine(int LineId)
        {

            try{
                var line =db.lines.Find(LineId);
                db.lines.Remove(line);
                db.SaveChanges();
                return true;
            } catch { return false; }
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
        //Busca Valor Total
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
        public List<LineType> GetLineType(int line)
        {
            try {

                List<LineType> lstLineType = db.lineType.ToList();
                return lstLineType;
            }
            catch { return new List<LineType>(); }
        
        
        }
        //busca todas as cidades
        public List<LineCity> GetLinesCity(int user) 
        {
            try { 
            List<LineCity> lineCities = db.lineCity.ToList();
                return lineCities;
            
            } catch { return new List<LineCity>(); }
        
        
        }
        //Busca Todos os tipos de linhas existentes
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
        public bool CreateExpense(string Month,int Year,string ExpenseStateId, string email, string ProjectId, decimal TotalMoney,string nameExpense)
        {
            try { 
           
                Expense obj = new Expense
                {
                    Month= Month,
                    Year= Year,
                    Expense_Name=nameExpense,
                    TotalMoney = TotalMoney,
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
        //Busca Todas as linhas da quela despesa
        public List<Line> GetLines(int expenseid)
        {
            try {

                List<Line> lstlines = db.lines.Where(l => l.ExpenseId.Equals(expenseid)).ToList();
                return lstlines;


            }
            catch {

                return new List<Line>();
            }
        
        
        
        }
        //Apaga a despesa com aquele id 
        public bool DeleteExpense(int expenseid) 
        {
            try
            {
                var exp = db.expenses.Where(e => e.Expense_Id.Equals(expenseid)).FirstOrDefault();
                List<Line> lstlines = db.lines.Where(l => l.ExpenseId.Equals(expenseid)).ToList();
                db.expenses.Remove(exp);
                foreach (Line ln in lstlines)
                {

                    db.lines.Remove(ln);

                }
                db.SaveChanges();
                return true;
            }
            catch { return false; }
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
        //Atualiza o Estado Da despesa
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
        public bool CreateLine(decimal UnityPrice,DateTime Date,string discription,string linecity,string lineType,int ExpenseID)
        {
            try
            {
                var obj = new Line
                {

                    UnityPrice = UnityPrice,
                    Date = Date,
                    Discription = discription,
                    lineCIty = db.lineCity.Where(lc => lc.City.Equals(linecity)).FirstOrDefault().LineCityID,
                    lineType = db.lineType.Where(lt => lt.Type.Equals(lineType)).FirstOrDefault().LineTypeID,
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
        public bool CreateBill(string image, string Name, int expenseId, string Type)
        {
            try
            {
                 var file = new Models.File
                {

                    base64 = image
                };
                db.files.Add(file);
                db.SaveChanges();

                var FileContent = new Models.FileContent
                {
                    Name = Name,
                    FileId =file.File_Id,
                    FileContentTypeId = db.fileContType.Where(fc => fc.Type.Equals(Type)).FirstOrDefault().FileContentType_Id
                };
                db.fileContents.Add(FileContent);
                db.SaveChanges();

                var ExpenseFileContent = new Models.Expense_File
                {
                    ExpenseId = expenseId,
                    FileContentId = FileContent.FileContent_Id
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
        public int GetExpenseId(int userid, string expensename)
        {
            try
            {
                List<Expense> lstexp = GetExpenses(userid);

                foreach (Expense e in lstexp)
                {
                    if (e.Expense_Name == expensename)
                    {
                        return e.Expense_Id;
                    }
                }
                return 0;
            }
            catch { return -1; }



        }
        public Expense getExpense(int expenseID)
        {
            try
            {
                Expense expense = db.expenses.Find(expenseID);
                return expense;
            }
            catch { return new Expense(); }
        }
        public Line GetLine(string line, int expenseid)
        {
            try
            {
                List<Line> lstline = GetLines(expenseid);

                var auxline = db.lineType.Where(lt => lt.Type.Equals(line)).FirstOrDefault().LineTypeID;
                Line linha = new Line();
                foreach (Line l in lstline)
                {

                    if (l.lineType == auxline)
                    {
                        linha = db.lines.Find(l.Cod_Line);

                    }
                }
                return linha;
            }
            catch
            {
                return new Line();
            }
        }

        public bool verifyExpense(int expenseID)
        {
            try
            {
                int aux = 0;
                if (db.expenses.Find(expenseID) == null)
                {
                    return false;

                }
                return true;


            }
            catch
            {
                return false;
            }
        }
        
        public int getLineId(int expenseId,string Type)
        {
            try
            {

                List<Line> lstline = GetLines(expenseId);
                int idlinetype = db.lineType.Where(lt => lt.Type.Equals(Type)).FirstOrDefault().LineTypeID;
                foreach (Line l in lstline)
                {
                    if (l.lineType == idlinetype) 
                    {
                        return l.Cod_Line;
                    }
                }
                return 0;

            }
            catch
            {
                return -1;
            }


        }
        public bool DeleteBill(string nameImage)
        {
            try
            {
                var file = db.files.Where(f => f.base64.Equals(nameImage)).FirstOrDefault().File_Id;
                var fl = db.files.Where(f => f.base64.Equals(nameImage)).FirstOrDefault();

                var content = db.fileContents.Where(fc => fc.FileId.Equals(file)).FirstOrDefault().FileContent_Id;
                var cntnt = db.fileContents.Where(fc => fc.FileId.Equals(file)).FirstOrDefault();
                Expense_File ExpenseContet = db.expenses_files.Find(content);

                db.expenses_files.Remove(ExpenseContet);
                db.fileContents.Remove(cntnt);
                db.files.Remove(fl);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
