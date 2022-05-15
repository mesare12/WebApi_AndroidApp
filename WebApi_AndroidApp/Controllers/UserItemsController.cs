#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_AndroidApp.Models;
using WebApi_AndroidApp.Utility;

namespace WebApi_AndroidApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserItemsController : ControllerBase
    {
        private readonly RockPaperScissor _context;

        public UserItemsController(RockPaperScissor context)
        {
            _context = context;
        }


       

        // POST: api/UserItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserItem>> PostUserItem(UserItem userItem)
        {
            _context.User.Add(userItem);
            userItem.PasswordHash = AuthUtil.ToSha256Hash(userItem.PasswordHash).Replace("-", "");
           
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserItem", new { id = userItem.UserID }, userItem);
        }

        // DELETE: api/UserItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserItem(long id)
        {
            var userItem = await _context.User.FindAsync(id);
            if (userItem == null)
            {
                return NotFound();
            }

            _context.User.Remove(userItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserItemExists(long id)
        {
            return _context.User.Any(e => e.UserID == id);
        }
    }
}
