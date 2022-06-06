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

        [HttpGet("{userId};{projectId}")]
        public IActionResult GetActivityUser([FromRoute] int userId, int projectId)
        {
            var ActivityUser_db = repos.GetActivityUser(userId, projectId);
            return Ok(ActivityUser_db);
        }

        [HttpGet("{day};{month};{year};{userId}")]
        public IActionResult GetUserWeekWorklog([FromRoute] int day, int month, int year, int userId)
        {
            var weekWorklog_db = repos.GetUserWeekWorklog(day, month, year, userId);
            return Ok(weekWorklog_db);
        }

        [HttpGet("{day};{month};{year}")]
        public IActionResult GetMondayDate([FromRoute] int day, int month, int year)
        {
            var mondayDate_db = repos.GetMondayDate(day, month, year);
            return Ok(mondayDate_db);
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

        [HttpGet("{worklogId}")]
        public IActionResult GetWorklog([FromRoute] int worklogId)
        {
            var worklogId_db = repos.GetWorklog(worklogId);
            return Ok(worklogId_db);
        }

        [HttpPost]
        public IActionResult PostWorklog(PostWorklogTimesheet worklog, int userId)
        {
            if (repos.CreateWorklog(worklog, userId))
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateWorklog(PutWorklogTimesheet worklog)
        {
            if (repos.UpdateWorklog(worklog))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{worklogId}")]
        public IActionResult DeleteWorklog([FromRoute] int worklog)
        {
            if (repos.DeleteWorklog(worklog))
                return Ok();

            return BadRequest();
        }
    }
}
