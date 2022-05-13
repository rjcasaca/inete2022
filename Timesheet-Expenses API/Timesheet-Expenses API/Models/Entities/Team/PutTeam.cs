namespace Timesheet_Expenses_API.Models.Entities.Team
{
    public class PutTeam:PostTeam
    {
        public int UserId { get; set; }
        public int ProjectId { get; set; }
    }
}
