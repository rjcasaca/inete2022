using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models
{
    [Table(name:"Worklog")]
    public class Worklog
    {
        [Key]
        public int Cod_Worklog { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public decimal Hours { get; set; }
        public string Comment { get; set; }

        //Navigation Properties
        public int UserId { get; set; }
        public User User { get; set; }

        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        public int BillingTypeId { get; set; }
        public BillingType BillingType { get; set; }

        public int WorklogStateId { get; set; }
        public WorklogState WorklogState { get; set; }
    }
}
