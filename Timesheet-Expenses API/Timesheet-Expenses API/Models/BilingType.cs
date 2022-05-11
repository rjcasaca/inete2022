using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models
{
    [Table(name:"Biling Type")]
    public class BilingType
    {
        [Key]
        public int BilingType_Id { get; set; }
        [MaxLength(50)]
        public string Type { get; set; }

        //Navigation Properties
        public List<Worklog> Worklog { get; set; }
    }
}
