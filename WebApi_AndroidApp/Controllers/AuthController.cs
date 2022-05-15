using WebApi_AndroidApp.ApiModels;
using WebApi_AndroidApp.Utility;
using WebApi_AndroidApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Net.Http.Headers;
using System.Text;

namespace WebApi_AndroidApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly RockPaperScissor _context;
        public AuthController(RockPaperScissor context)
        {
            _context = context;
        }


        /// <summary>
        /// Metod för inloggning med basic authentication
        /// </summary>
        /// <returns></returns>
        [Route("BasicLogin")]
        [HttpPost]
        public async Task<ActionResult<ApiLoginResponse>> BasicAuth()
        {
            var request = HttpContext.Request;
            StringValues authHeader = request.Headers["Authorization"];

            var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);

            // RFC 2617 sec 1.2, "scheme" name is case-insensitive
            if (authHeaderVal.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) &&
                authHeaderVal.Parameter != null)
            {
                var encoding = Encoding.GetEncoding("iso-8859-1");
                var bytes = Convert.FromBase64String(authHeaderVal.Parameter);
                var userAndPassword = encoding.GetString(bytes);

                var splitted = userAndPassword.Split(':');

                return await Authenticate(new ApiLoginUser() { Username = splitted[0], Password = splitted[1] });
            }

            return new UnauthorizedResult();
        }

        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult<ApiLoginResponse>> Login(ApiLoginUser user)
        {
            return await Authenticate(user);
        }

        private async Task<ActionResult<ApiLoginResponse>> Authenticate(ApiLoginUser user)
        {
            var hash = AuthUtil.ToSha256Hash(user.Password).Replace("-", "");
            var dbUser = _context.User.FirstOrDefault(x => 
                x.UserName.Equals(user.Username) && x.PasswordHash.Equals(hash)
            );
            if (dbUser == null) return NotFound();

            dbUser.TokenIssued = DateTime.Now;
            dbUser.Token = AuthUtil.SecureRandomString(30);
            await _context.SaveChangesAsync();

            return new ApiLoginResponse(dbUser);
        }

        [Route("Logout")]
        [HttpPost]
        public async Task<ActionResult> Logout(ApiLogout user)
        {

            var dbUser = _context.User.FirstOrDefault(x => x.Token.EndsWith(user.Token));
            if (dbUser != null)
            {
                dbUser.TokenIssued = DateTime.Parse("2000-01-01");
                await _context.SaveChangesAsync();
            }

            return new OkResult();
        }

       
    }
}
