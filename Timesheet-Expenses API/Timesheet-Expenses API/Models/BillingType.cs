using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models
{
    [Table(name:"Billing Type")]
    public class BillingType
    {
        [Key]
        public int BillingType_Id { get; set; }
        [Required, MaxLength(50)]
        public string Type { get; set; }

        //Navigation Properties
        public List<Worklog> Worklog { get; set; }
    }
}
