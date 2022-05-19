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

        [HttpGet("{Email}")]
        public IActionResult GetUserId([FromRoute] TimesheetUserInfo userInfo)
        {
            var uId_db = repos.GetUserId(userInfo.Email);
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

        [HttpGet("{date};{userId}")]
        public IActionResult GetUserWeekWorklog([FromRoute] DateTime date, int userId)
        {
            var weekWorklog_db = repos.GetUserWeekWorklog(date, userId);
            return Ok(weekWorklog_db);
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

        [HttpGet("{fileContId}")]
        public IActionResult GetFile([FromRoute] int fileContId)
        {
            var file_db = repos.GetFile(fileContId);
            return Ok(file_db);
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

        [HttpDelete("{worklog}")]
        public IActionResult DeleteWorklog([FromRoute] int worklog)
        {
            if (repos.DeleteWorklog(worklog))
                return Ok();

            return BadRequest();
        }
    }
}
