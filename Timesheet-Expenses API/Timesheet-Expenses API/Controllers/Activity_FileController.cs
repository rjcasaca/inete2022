using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Timesheet_Expenses_API.Models.Entities.Activity_File;
using Timesheet_Expenses_API.Repositories;

namespace Timesheet_Expenses_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Activity_FileController : Controller
    {
        private readonly IActivity_FileRepository repos;

        public Activity_FileController(IActivity_FileRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet("{Activity_Id};{FileContent_Id}")]
        public IActionResult Get([FromRoute] Activity_FileId activity_File)
        {
            var activity_File_db = repos.Read(activity_File.Activity_Id, activity_File.FileContent_Id);

            return Ok(activity_File_db);
        }

        [HttpPost]
        public IActionResult Post(PostActivity_File activity_File)
        {
            if (repos.Create(activity_File))
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(PutActivity_File activity_File)
        {
            if (repos.Update(activity_File))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{Activity_Id};{FileContent_Id}")]
        public IActionResult Delete([FromRoute] Activity_FileId activity_File)
        {
            if (repos.Delete(activity_File.Activity_Id, activity_File.FileContent_Id))
                return Ok();

            return BadRequest();
        }
    }
}
