namespace Timesheet_Expenses_API.Models.Object.Timesheet
{
    public class TeamInfo
    {
        public string Name { get; set; }
        public List<TimesheetUserInfo> UserInfo { get; set; }
    }
}
