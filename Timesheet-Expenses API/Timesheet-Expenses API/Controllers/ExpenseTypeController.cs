using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Timesheet_Expenses_API.Models.Entities.ExpenseType;
using Timesheet_Expenses_API.Repositories;

namespace Timesheet_Expenses_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseTypeController : Controller
    {
        private readonly IExpenseTypeRepository repos;

        public ExpenseTypeController(IExpenseTypeRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet("{ExpenseType_Id}")]
        public IActionResult Get([FromRoute] ExpenseTypeId expenseType)
        {
            var expenseType_db = repos.Read(expenseType.ExpenseType_Id);

            return Ok(expenseType_db);
        }

        [HttpPost]
        public IActionResult Post(PostExpenseType expenseType)
        {
            if (repos.Create(expenseType))
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(PutExpenseType expenseType)
        {
            if (repos.Update(expenseType))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{ExpenseType_Id}")]
        public IActionResult Delete([FromRoute] ExpenseTypeId expenseType)
        {
            if (repos.Delete(expenseType.ExpenseType_Id))
                return Ok();

            return BadRequest();
        }
    }
}
