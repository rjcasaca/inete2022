using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Timesheet_Expenses_API.Models.Entities.Expense_File;
using Timesheet_Expenses_API.Repositories;

namespace Timesheet_Expenses_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Expense_FileController : Controller
    {
        private readonly IExpense_FileRepository repos;

        public Expense_FileController(IExpense_FileRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet("{ExpensesId};{FileContentId}")]
        public IActionResult Get([FromRoute] Expense_FileId expense_File)
        {
            var expense_File_db = repos.Read(expense_File.ExpensesId, expense_File.FileContentId);

            return Ok(expense_File_db);
        }

        [HttpPost]
        public IActionResult Post(PostExpense_File expense_File)
        {
            if (repos.Create(expense_File))
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(PutExpense_File expense_File)
        {
            if (repos.Update(expense_File))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{ExpensesId};{FileContentId}")]
        public IActionResult Delete([FromRoute] Expense_FileId expense_File)
        {
            if (repos.Delete(expense_File.ExpensesId, expense_File.FileContentId))
                return Ok();

            return BadRequest();
        }
    }
}
