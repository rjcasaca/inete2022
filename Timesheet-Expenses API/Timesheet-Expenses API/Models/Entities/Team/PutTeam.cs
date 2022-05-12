namespace Timesheet_Expenses_API.Models.Entities.Team
{
    public class PutTeam:PostTeam
    {
        public int User_Id { get; set; }
        public int Project_Id { get; set; }
    }
}
