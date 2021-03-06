using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models
{
    [Table(name: "Project State")]
    public class ProjectState
    {
        [Key]
        public int ProjectState_Id { get; set; }
        [Required, MaxLength(30)]
        public string State { get; set; }

        //Navigation Properties
        public List<Project> Project { get; set; }
    }
}
