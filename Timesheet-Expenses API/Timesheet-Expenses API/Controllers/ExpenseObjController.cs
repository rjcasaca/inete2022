using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Timesheet_Expenses_API.Models.Object.Expense;
using Timesheet_Expenses_API.Repositories;
using Timesheet_Expenses_API.Models;

namespace Timesheet_Expenses_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExpenseObjController : ControllerBase
    {
        private readonly IExepensesObjectsRep repos;
        public ExpenseObjController(IExepensesObjectsRep _repos)
        {
            repos = _repos;
        }

        [HttpGet("{email}")]
        public IActionResult GetUserInfo([FromRoute] string email)
        {
            var user_db = repos.GetUserId(email);

            return Ok(user_db);
        }

        [HttpGet("{user}")]
        public IActionResult ValueAproved([FromRoute]int user)
        {
            var user_db = repos.ValueAproved(user);

            return Ok(user_db);
        }

        [HttpGet("{userid}")]
        public IActionResult GetExpenses([FromRoute] int userid)
        {
            var user = repos.GetExpenses(userid);

            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateExpense(ExpObj expense)
        {
            if (repos.CreateExpense(expense))
                return Ok();

            return BadRequest();
        }

        [HttpPut]

        public IActionResult PutLine(int expenseid)
        {
            if (repos.PutLine(expenseid))
                return Ok();

            return BadRequest();
        }

        [HttpPost]
        public IActionResult CreateLine(LinesObj line)
        {
            if (repos.CreateLine(line))
                return Ok();

            return BadRequest();
        }
       
        [HttpPost]
        public IActionResult CreateBill(Bill bill)
        {
            if (repos.CreateBill(bill))
                return Ok();

            return BadRequest();
        }
    }
}
