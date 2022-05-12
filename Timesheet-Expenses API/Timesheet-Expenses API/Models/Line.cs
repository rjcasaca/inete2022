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

        //Navigation Properties
        public Expense Expense { get; set; }
    }
}
