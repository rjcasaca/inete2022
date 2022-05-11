using System.ComponentModel.DataAnnotations;

namespace Timesheet_Expenses_API.Models.Entities.BillingType
{
    public class PostBillingType
    {
        [Required, MaxLength(50)]
        public string Type { get; set; }
    }
}
