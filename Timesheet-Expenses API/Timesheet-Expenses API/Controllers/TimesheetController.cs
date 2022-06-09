﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{day};{month};{year};{AddDays}")]
        public IActionResult AddDays([FromRoute] int day, int month, int year, int AddDays)
        {
            var newDate_db = repos.AddDays(day, month, year, AddDays);
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

        [HttpGet("{worklogId}")]
        public IActionResult GetWorklog([FromRoute] int worklogId)
        {
            var worklogId_db = repos.GetWorklog(worklogId);
            return Ok(worklogId_db);
        }

        [HttpPost("{day};{month};{year};{hours};{comment};{activity};{billingType};{worklogState};{userId}")]
        public IActionResult CreateWorklog([FromRoute] int day, int month, int year, decimal hours, string comment, int activity, string billingType, string worklogState, int userId)
        {
            if (repos.CreateWorklog(day, month, year, hours, comment, activity, billingType, worklogState, userId))
                return Ok();

            return BadRequest();
        }

        [HttpPost("{Eday};{Emonth};{Eyear};{Sday};{Smonth};{Syear};{hours};{comment};{activity};{billingType};{worklogState};{userId}")]
        public IActionResult CreateWorklogByPeriod([FromRoute] int Eday, int Emonth, int Eyear, int Sday, int Smonth, int Syear, decimal hours, string comment, int activity, string billingType, string worklogState, int userId)
        {
            if (repos.CreateWorklogByPeriod(Eday, Emonth, Eyear, Sday, Smonth, Syear, hours, comment, activity, billingType, worklogState, userId))
                return Ok();

            return BadRequest();
        }

        [HttpPut("{worklogId};{hours};{comment};{billingType};{worklogState}")]
        public IActionResult UpdateWorklog([FromRoute] int worklogId, decimal hours, string comment, string billingType, string worklogState)
        {
            if (repos.UpdateWorklog(worklogId, hours, comment, billingType, worklogState))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{worklogId}")]
        public IActionResult DeleteWorklog([FromRoute] int worklogId)
        {
            if (repos.DeleteWorklog(worklogId))
                return Ok();

            return BadRequest();
        }
    }
}
