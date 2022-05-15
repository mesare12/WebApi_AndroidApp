#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_AndroidApp.ApiModels;
using WebApi_AndroidApp.Models;

namespace WebApi_AndroidApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly RockPaperScissor _context;
        public MessagesController(RockPaperScissor context)
        {
            _context = context;
        }




        [Route("RetriveNewMessages")]
        [HttpPost]
        public async Task<ActionResult<List<ApiMessage>>> GetMessages(ApiToken token)
        {
            var user = _context.User.FirstOrDefault(x => x.Token.Equals(token.Value));
            if (user == null) return new UnauthorizedResult();

            var messages = await _context.Message
                .Where(row => row.ToUserID == user.UserID)
                .Select(row => new ApiMessage(row, _context))
                .ToListAsync();


            return messages;
        }

    }
}
