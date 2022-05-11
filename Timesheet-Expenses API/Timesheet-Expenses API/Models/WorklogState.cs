using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models
{
    [Table(name:"Worklog State")]
    public class WorklogState
    {
        [Key]
        public int WorklogState_Id { get; set; }
        [MaxLength(50)]
        public string State { get; set; }

        //Navigation Properties
        public List<Worklog> Worklog { get; set; }
    }
}
