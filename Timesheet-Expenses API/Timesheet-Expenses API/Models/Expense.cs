using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models
{
    [Table(name:"Expense")]
    public class Expense
    {
        [Key]
        public int Expense_Id { get; set; }
        public string Expense_Name { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public decimal TotalMoney { get; set; }

        //Navigation Properties

        public string ExpenseState { get; set; }
      

        public int UserId { get; set; }
     

        public int ProjectId { get; set; }


        public List<Line> Line { get; set; }
    }
}
