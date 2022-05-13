using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Timesheet_Expenses_API.Models.Entities.ExpenseState;
using Timesheet_Expenses_API.Repositories;

namespace Timesheet_Expenses_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseStateController : Controller
    {
        private readonly IExpenseStateRepository repos;

        public ExpenseStateController(IExpenseStateRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet("{ExpenseState_Id}")]
        public IActionResult Get([FromRoute] ExpenseStateId expenseState)
        {
            var expenseState_db = repos.Read(expenseState.ExpenseState_Id);

            return Ok(expenseState_db);
        }

        [HttpPost]
        public IActionResult Post(PostExpenseState expenseState)
        {
            if (repos.Create(expenseState))
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(PutExpenseState expenseState)
        {
            if (repos.Update(expenseState))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{ExpenseState_Id}")]
        public IActionResult Delete([FromRoute] ExpenseStateId expenseState)
        {
            if (repos.Delete(expenseState.ExpenseState_Id))
                return Ok();

            return BadRequest();
        }
    }
}
