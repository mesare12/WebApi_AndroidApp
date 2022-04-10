using WebApi_AndroidApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi_AndroidApp.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly RockPaperScissor _context;

        public TokenController(IConfiguration config, RockPaperScissor context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserItem _userData)
        {
            if (_userData != null && _userData.UserEmail != null && _userData.PasswordHash != null)
            {
                var user = await GetUser(_userData.UserEmail, _userData.PasswordHash);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.UserID.ToString()),
                        new Claim("FirstName", user.FirstName!),
                        new Claim("UserName", user.UserName!),
                        new Claim("Email", user.UserEmail!),
                        new Claim(ClaimTypes.Role, user.Role!)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<UserItem> GetUser(string email, string password)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.UserEmail == email && u.PasswordHash == password);
        }
    }
}
