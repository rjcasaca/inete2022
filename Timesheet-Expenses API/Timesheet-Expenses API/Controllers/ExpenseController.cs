using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Timesheet_Expenses_API.Models.Entities.Expense;
using Timesheet_Expenses_API.Repositories;

namespace Timesheet_Expenses_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : Controller
    {
        private readonly IExpenseRepository repos;

        public ExpenseController(IExpenseRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet("{Expense_Id}")]
        public IActionResult Get([FromRoute] ExpenseId expense)
        {
            var expense_db = repos.Read(expense.Expense_Id);

            return Ok(expense_db);
        }

        [HttpPost]
        public IActionResult Post(PostExpense expense)
        {
            if (repos.Create(expense))
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(PutExpense expense)
        {
            if (repos.Update(expense))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{Expense_Id}")]
        public IActionResult Delete([FromRoute] ExpenseId expense)
        {
            if (repos.Delete(expense.Expense_Id))
                return Ok();

            return BadRequest();
        }
    }
}
