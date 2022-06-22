using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models
{[Table(name:"Line")]
    public class Line
    {
        [Key]
        public int Cod_Line { get; set; }
        public decimal UnityPrice { get; set; }
        public DateTime Date { get; set; }
        public string Discription { get; set; }
        public decimal period { get; set; }
        public int lineCIty { get; set; }
        public int lineType { get; set; }
        //Navigation Properties
        public int ExpenseId { get; set; }
        public Expense Expense { get; set; }

        
    }
}
