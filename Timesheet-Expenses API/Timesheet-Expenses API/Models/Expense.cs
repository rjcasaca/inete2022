using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models
{
    [Table(name:"Expense")]
    public class Expense
    {
        [Key]
        public int Expense_Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalMoney { get; set; }

        //Navigation Properties
        public int ExpenseTypeId { get; set; }
       

        public int ExpenseStateId { get; set; }
      

        public int UserId { get; set; }
     

        public int ProjectId { get; set; }
  
     
       
    }
}
