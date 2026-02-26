using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assessment12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SecureController : ControllerBase
    {
        // Role-based
        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminOnly()
        {
            return Ok("Admin Access Granted");
        }

        // Role-based
        [HttpGet("user")]
        [Authorize(Roles = "User")]
        public IActionResult UserOnly()
        {
            return Ok("User Access Granted");
        }

        // Policy-based
        [HttpGet("policy-admin")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult PolicyAdmin()
        {
            return Ok("Policy Admin Access");
        }

        // Multiple roles
        [HttpGet("common")]
        [Authorize(Policy = "AdminOrUser")]
        public IActionResult Common()
        {
            return Ok("Both Admin & User can access");
        }
    }
}