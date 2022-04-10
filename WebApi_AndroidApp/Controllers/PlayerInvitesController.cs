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

namespace WebApi_AndroidApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerInvitesController : ControllerBase
    {
        private readonly RockPaperScissor _context;

        public PlayerInvitesController(RockPaperScissor context)
        {
            _context = context;
        }

        // GET: api/PlayerInvites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerInvite>>> GetPlayerInvite()
        {
            return await _context.PlayerInvite.ToListAsync();
        }

        // GET: api/PlayerInvites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerInvite>> GetPlayerInvite(long id)
        {
            var playerInvite = await _context.PlayerInvite.FindAsync(id);

            if (playerInvite == null)
            {
                return NotFound();
            }

            return playerInvite;
        }

        // PUT: api/PlayerInvites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerInvite(long id, PlayerInvite playerInvite)
        {
            if (id != playerInvite.InviteFromUserID)
            {
                return BadRequest();
            }

            _context.Entry(playerInvite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerInviteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PlayerInvites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlayerInvite>> PostPlayerInvite(PlayerInvite playerInvite)
        {
            _context.PlayerInvite.Add(playerInvite);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlayerInviteExists(playerInvite.InviteFromUserID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlayerInvite", new { id = playerInvite.InviteFromUserID }, playerInvite);
        }

        // DELETE: api/PlayerInvites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerInvite(long id)
        {
            var playerInvite = await _context.PlayerInvite.FindAsync(id);
            if (playerInvite == null)
            {
                return NotFound();
            }

            _context.PlayerInvite.Remove(playerInvite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerInviteExists(long id)
        {
            return _context.PlayerInvite.Any(e => e.InviteFromUserID == id);
        }
    }
}
