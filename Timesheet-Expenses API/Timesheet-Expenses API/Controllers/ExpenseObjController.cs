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
        [HttpGet("{user}")]
        public IActionResult ValuePending([FromRoute] int user)
        {
            var user_db = repos.ValuePending(user);

            return Ok(user_db);
        }
        [HttpGet("{user}")]
        public IActionResult ValueDenied([FromRoute] int user)
        {
            var user_db = repos.ValueDenied(user);

            return Ok(user_db);
        }
        [HttpGet("{userid}")]
        public IActionResult GetExpenses([FromRoute] int userid)
        {
            var user = repos.GetExpenses(userid);

            return Ok(user);
        }
        [HttpGet("{user}")]
        public IActionResult GetTypeList([FromRoute] int user)
        {
            var userid = repos.GetTypeList(user);

            return Ok(userid);
        }
        [HttpPost("{data};{ExpenseType};{ExpenseStateId};{email};{ProjectId};{TotalMoney}")]
        public IActionResult CreateExpense([FromRoute] DateTime data, string ExpenseType, string ExpenseStateId, string email, string ProjectId, decimal TotalMoney)
        {
            if (repos.CreateExpense(data, ExpenseType, ExpenseStateId, email, ProjectId, TotalMoney))
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
