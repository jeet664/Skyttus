using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Assessment12.Models;
using Assessment12.Data;

namespace Assessment12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly string secretKey = "THIS_IS_MY_SUPER_SECRET_KEY_FOR_JWT_AUTHENTICATION_2026";

        [HttpPost("login")]
        public IActionResult Login(UserLogin login)
        {
            var user = UserRepository.Users
                .FirstOrDefault(u =>
                    u.Email == login.Email &&
                    u.Password == login.Password);

            if (user == null)
                return Unauthorized("Invalid credentials");

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(secretKey));

            var creds = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler()
                .WriteToken(token);

            return Ok(new
            {
                token = jwt,
                role = user.Role
            });
        }
    }
}