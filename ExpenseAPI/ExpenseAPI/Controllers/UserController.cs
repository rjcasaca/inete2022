using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() 
        { 
        return Ok();
        
        
        }


        [HttpPost]
        public IActionResult Post() { return Ok(); }
        [HttpPut]
        public IActionResult Pt() { return Ok(); }
        [HttpDelete]
        public IActionResult Delete() { return Ok(); }

    }
}
