using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models
{
    [Table(name:"Worklog")]
    public class Worklog
    {
        [Key]
        public int Cod_Worklog { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public decimal Hours { get; set; }
        public string Comment { get; set; }

        //Navigation Properties
        public User User { get; set; }
        public Activity Activity { get; set; }
        public BillingType BillingType { get; set; }
        public WorklogState WorklogState { get; set; }
    }
}
