﻿using Timesheet_Expenses_API.Models;
using Timesheet_Expenses_API.Models.Object.Expense;

namespace Timesheet_Expenses_API.Repositories
{
    public interface IExepensesObjectsRep
    {
        public int GetUserId(string email);
        public List<Expense> GetExpenses(int userId);
        public bool CreateExpense(ExpObj expense);
        public bool PutLine(int expenseid);
        public bool CreateLine(LinesObj line);
        public bool CreateBill(Bill bill);
        public decimal ValueAproved(int userid);
        public List<ExpenseType> GetTypeList(int user);
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
        public decimal ValueAproved(int userid)
        {
            try 
            {
                decimal Result = db.expenses.Where(l => l.ExpenseStateId.Equals(userid)).Sum(l => l.TotalMoney);


                return Result;
            }
            catch {

                return -1;
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
        public bool CreateExpense(ExpObj newExpense)
        {
            try
            {
                var obj = new Expense
                {
                    Date = newExpense.Date,
                    TotalMoney = 0,
                    ExpenseTypeId = db.expenseType.Where(e => e.Type.Equals(newExpense.ExpenseType)).FirstOrDefault().ExpenseType_Id,
                    ExpenseStateId= db.expenseState.Where(es=>es.State.Equals(newExpense.ExpenseState)).FirstOrDefault().ExpenseState_Id,
                    UserId = GetUserId(newExpense.User),
                    ProjectId= db.projects.Where(p => p.Name.Equals(newExpense.project_name)).FirstOrDefault().Project_Id
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

        //cria um line 
        public bool CreateLine(LinesObj line)
        {
            try
            { 
                var obj = new Line
                {

                    UnityPrice = line.UnityPrice,
                    Date = line.Date,
                    ExpenseId = line.Expense
                    
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
       
        public bool CreateBill(Bill bill)
        {
            try
            {
                var file = new Models.File
                {

                    File_Id = bill.FileId,
                    base64 = bill.base64
                };
                db.files.Add(file);
                db.SaveChanges();

                var fileContentType = new Models.FileContentType
                {
                    FileContentType_Id = bill.FileContentId,
                    Type = bill.Type
                };
                db.fileContType.Add(fileContentType);
                db.SaveChanges();

                var FileContent = new Models.FileContent
                {
                    Name = bill.Name,
                    FileId = bill.FileId,
                    FileContentTypeId = bill.FileContentId
                };
                db.fileContents.Add(FileContent);
                db.SaveChanges();

                var ExpenseFileContent = new Models.Expense_File
                {
                    ExpenseId = bill.expenseid,
                    FileContentId = bill.FileContent_Id
                };
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
