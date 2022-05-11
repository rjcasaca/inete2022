using System.ComponentModel.DataAnnotations;

namespace Timesheet_Expenses_API.Models.Entities.Worklog
{
    public class PostWorklog
    {
        public DateTime Date { get; set; }
        [Required]
        public decimal Hours { get; set; }
        public string Comment { get; set; }

        //Navigation Properties
        public Models.User User { get; set; }
        public Models.Activity Activity { get; set; }
        public Models.BillingType BillingType { get; set; }
        public Models.WorklogState WorklogState { get; set; }
    }
}
