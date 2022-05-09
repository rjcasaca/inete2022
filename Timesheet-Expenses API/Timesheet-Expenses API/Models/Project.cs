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
        public List<Client> Client { get; set; }
        public List<ProjectState> ProjectState { get; set; }
        public List<Team> teams { get; set; }
    }
}
