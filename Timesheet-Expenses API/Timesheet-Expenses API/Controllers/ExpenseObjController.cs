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
        [HttpDelete("{nameImage}")]
        public IActionResult DeleteBill([FromRoute] string nameImage)
        {
            var deleteBill = repos.DeleteBill(nameImage);
            return Ok(deleteBill);
        }
        [HttpGet("{email}")]
        public IActionResult GetUserInfo([FromRoute] string email)
        {
            var user_db = repos.GetUserId(email);

            return Ok(user_db);
        }
        [HttpGet("{user};{expensename}")]
        public IActionResult GetExpenseId([FromRoute] int user, string expensename)
        {
            var expenseid = repos.GetExpenseId(user, expensename);

            return Ok(expenseid);
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
        public IActionResult ValueTotal([FromRoute] int user)
        {
            var user_db = repos.ValueTotal(user);

            return Ok(user_db);
        }


        [HttpGet("{user}")]
        public IActionResult GetLineType([FromRoute] int user)
        {
            var lstlinestype = repos.GetLineType(user);

            return Ok(lstlinestype);
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

        [HttpGet("{expenseid}")]
        public IActionResult GetLines([FromRoute] int expenseid)
        {
            var lstlines = repos.GetLines(expenseid);

            return Ok(lstlines);
        }

        [HttpDelete("{LineId}")]
        public IActionResult DeleteLine([FromRoute] int LineId)
        {
            var deleteline = repos.DeleteLine(LineId);
            return Ok(deleteline);
        }

        [HttpDelete("{expenseid}")]
        public IActionResult DeleteExpense([FromRoute] int expenseid)
        {
            var deleteExp = repos.DeleteExpense(expenseid);
            return Ok(deleteExp);
        }

        [HttpGet("{user}")]
        public IActionResult GetTypeList([FromRoute] int user)
        {
            var userid = repos.GetTypeList(user);

            return Ok(userid);
        }

        [HttpPost("{Month};{Year};{ExpenseStateId};{email};{ProjectId};{TotalMoney};{nameExpense}")]
        public IActionResult CreateExpense([FromRoute] string Month, int Year, string ExpenseStateId, string email, string ProjectId, decimal TotalMoney, string nameExpense)
        {
            if (repos.CreateExpense( Month,  Year,  ExpenseStateId,  email,  ProjectId,  TotalMoney,  nameExpense))
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

        [HttpPut]
        public IActionResult UpdateState(int expenseid, string newstate)
        {
            if (repos.UpdateState(expenseid, newstate))
                return Ok();

            return BadRequest();
        }

        [HttpPost("{UnityPrice};{Date};{discription};{linecity};{lineType};{ExpenseID}")]
        public IActionResult CreateLine([FromRoute] decimal UnityPrice, DateTime Date, string discription, string linecity, string lineType, int ExpenseID)
        {
            if (repos.CreateLine(UnityPrice,Date,discription,linecity,lineType,ExpenseID))
                return Ok();

            return BadRequest();
        }

        [HttpPost("{image};{Name};{expenseId};{Type}")]
        public IActionResult CreateBill([FromRoute] string image, string Name, int expenseId, string Type)
        {
            if (repos.CreateBill(image, Name, expenseId, Type))
                return Ok();

            return BadRequest();
        }
        [HttpGet("{user}")]
        public IActionResult GetLinesCity([FromRoute] int user)
        {
            var LinesCity = repos.GetLinesCity(user);

            return Ok(LinesCity);
        }
        [HttpGet("{expenseId};{Type}")]
        public IActionResult getLineId([FromRoute] int expenseId, string Type)
        {
            var lineid = repos.getLineId( expenseId,  Type);

            return Ok(lineid);
        }
        [HttpGet("{expenseID}")]
        public IActionResult getExpense([FromRoute] int expenseID)
        {
            var getexpense = repos.getExpense(expenseID);

            return Ok(getexpense);
        }
        [HttpGet("{line};{expenseID}")]
        public IActionResult GetLine([FromRoute] string line, int expenseID)
        {
            var Getline = repos.GetLine(line, expenseID);

            return Ok(Getline);
        }

        [HttpGet("{expenseID}")]
        public IActionResult verifyExpense([FromRoute] int expenseID)
        {
            var Verify = repos.verifyExpense(expenseID);

            return Ok(Verify);
        }
    }
}
