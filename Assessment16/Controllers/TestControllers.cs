using Microsoft.AspNetCore.Mvc;

namespace Assessment16.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("API is running securely!");
        }

        [HttpGet("error")]
        public IActionResult ThrowError()
        {
            throw new Exception("This is a test exception");
        }
    }
}