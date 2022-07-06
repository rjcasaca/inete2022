using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Timesheet_Expenses_API.Models.Object.Timesheet;
using Timesheet_Expenses_API.Repositories;

namespace Timesheet_Expenses_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TimesheetController : Controller
    {
        private readonly ITimesheetRepository repos;

        public TimesheetController(ITimesheetRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet]
        public IActionResult GetBillingTypes()
        {
            var BillingTypes_db = repos.GetBillingTypes();
            return Ok(BillingTypes_db);
        }

        [HttpGet]
        public IActionResult GetWorklogState()
        {
            var WorklogState_db = repos.GetWorklogState();
            return Ok(WorklogState_db);
        }

        [HttpGet("{userEmail}")]
        public IActionResult GetUserId([FromRoute] string userEmail)
        {
            var uId_db = repos.GetUserId(userEmail);
            return Ok(uId_db);
        }

        [HttpGet("{userId}")]
        public IActionResult GetProjectUser([FromRoute] int userId)
        {
            var projects_db = repos.GetProjectUser(userId);
            return Ok(projects_db);
        }

        [HttpGet("{userId}")]
        public IActionResult GetProjectHour([FromRoute] int userId)
        {
            var ProjectHours_db = repos.GetProjectHour(userId);
            return Ok(ProjectHours_db);
        }

        [HttpGet("{userId};{projectId}")]
        public IActionResult GetActivityHours([FromRoute] int userId, int projectId)
        {
            var ActivityHours_db = repos.GetActivityHours(userId, projectId);
            return Ok(ActivityHours_db);
        }

        [HttpGet("{userId};{activityId}")]
        public IActionResult GetUserActivityWorklogs([FromRoute] int userId, int activityId)
        {
            var GetUserActivityWorklogs_db = repos.GetUserActivityWorklogs(userId, activityId);
            return Ok(GetUserActivityWorklogs_db);
        }

        [HttpGet("{userId};{projectId}")]
        public IActionResult GetActivityUser([FromRoute] int userId, int projectId)
        {
            var ActivityUser_db = repos.GetActivityUser(userId, projectId);
            return Ok(ActivityUser_db);
        }

        [HttpGet("{date};{userId}")]
        public IActionResult GetUserWeekWorklog([FromRoute] DateTime date, int userId)
        {
            var weekWorklog_db = repos.GetUserWeekWorklog(date, userId);
            return Ok(weekWorklog_db);
        }

        [HttpGet("{date};{AddDays}")]
        public IActionResult AddDays([FromRoute] DateTime date, int AddDays)
        {
            var newDate_db = repos.AddDays(date, AddDays);
            return Ok(newDate_db);
        }

        [HttpGet("{activityId}")]
        public IActionResult GetActivitiesInfo([FromRoute] int activityId)
        {
            var activityInfo_db = repos.GetActivitiesInfo(activityId);
            return Ok(activityInfo_db);
        }

        [HttpGet("{projectId}")]
        public IActionResult GetProjectInfo([FromRoute] int projectId)
        {
            var projectInfo_db = repos.GetProjectInfo(projectId);
            return Ok(projectInfo_db);
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserInfo([FromRoute] int userId)
        {
            var userInfo_db = repos.GetUserInfo(userId);
            return Ok(userInfo_db);
        }

        [HttpGet("{worklogId}")]
        public IActionResult GetWorklog([FromRoute] int worklogId)
        {
            var worklogId_db = repos.GetWorklog(worklogId);
            return Ok(worklogId_db);
        }

        [HttpPost("{date};{hours};{comment};{activity};{billingType};{worklogState};{userId}")]
        public IActionResult CreateWorklog([FromRoute] DateTime date, decimal hours, string comment, int activity, string billingType, string worklogState, int userId)
        {
            var createWl = repos.CreateWorklog(date, hours, comment, activity, billingType, worklogState, userId);
            return Ok(createWl);
        }

        [HttpPost("{EndDate};{StartDate};{hours};{comment};{activity};{billingType};{worklogState};{userId}")]
        public IActionResult CreateWorklogByPeriod([FromRoute] DateTime EndDate, DateTime StartDate, decimal hours, string comment, int activity, string billingType, string worklogState, int userId)
        {
            var createWl = repos.CreateWorklogByPeriod(EndDate, StartDate, hours, comment, activity, billingType, worklogState, userId);
            return Ok(createWl);
        }

        [HttpPut("{worklogId};{hours};{comment};{billingType};{worklogState}")]
        public IActionResult UpdateWorklog([FromRoute] int worklogId, decimal hours, string comment, string billingType, string worklogState)
        {
            var updateWl = repos.UpdateWorklog(worklogId, hours, comment, billingType, worklogState);
            return Ok(updateWl);
        }

        [HttpDelete("{worklogId}")]
        public IActionResult DeleteWorklog([FromRoute] int worklogId)
        {
            var deleteWl = repos.DeleteWorklog(worklogId);
            return Ok(deleteWl);
        }
    }
}
