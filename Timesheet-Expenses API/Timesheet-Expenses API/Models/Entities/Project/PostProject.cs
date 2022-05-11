using System.ComponentModel.DataAnnotations;

namespace Timesheet_Expenses_API.Models.Entities.Project
{
    public class PostProject
    {
        [MaxLength(150)]
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //Navigation Properties
        public Models.Client Client { get; set; }
        public Models.ProjectState ProjectState { get; set; }
    }
}
