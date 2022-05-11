namespace Timesheet_Expenses_API.Models.Entities.Team
{
    public class PutTeam:PostTeam
    {
        public int userID { get; set; }
        public int projectID { get; set; }
    }
}
