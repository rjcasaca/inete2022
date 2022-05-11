using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models
{
    [Table(name:"Project")]
    public class Project
    {
        [Key]
        public int Project_Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //Navigation Properties
        public Client Client { get; set; }
        public ProjectState ProjectState { get; set; }
        public List<Team> Team { get; set; }
        public List<Activity> Activity { get; set; }
        public List<Expense> Expenses { get; set; }

    }
}
