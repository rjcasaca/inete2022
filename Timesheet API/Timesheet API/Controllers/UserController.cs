using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Timesheet_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post()
        {
            try
            {
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put()
        {
            try
            {
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IActionResult Delete() 
        {
            try
            {
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
