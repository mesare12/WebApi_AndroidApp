#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_AndroidApp.Models;

namespace WebApi_AndroidApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerMoveItemsController : ControllerBase
    {
        private readonly RockPaperScissor _context;

        public PlayerMoveItemsController(RockPaperScissor context)
        {
            _context = context;
        }

        // GET: api/PlayerMoveItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerMoveItem>>> GetPlayerMoves()
        {
            return await _context.PlayerMoves.ToListAsync();
        }

        // GET: api/PlayerMoveItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerMoveItem>> GetPlayerMoveItem(short id)
        {
            var playerMoveItem = await _context.PlayerMoves.FindAsync(id);

            if (playerMoveItem == null)
            {
                return NotFound();
            }

            return playerMoveItem;
        }

        // PUT: api/PlayerMoveItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerMoveItem(short id, PlayerMoveItem playerMoveItem)
        {
            if (id != playerMoveItem.MoveID)
            {
                return BadRequest();
            }

            _context.Entry(playerMoveItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerMoveItemExists(id))
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

        // POST: api/PlayerMoveItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlayerMoveItem>> PostPlayerMoveItem(PlayerMoveItem playerMoveItem)
        {
            _context.PlayerMoves.Add(playerMoveItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayerMoveItem", new { id = playerMoveItem.MoveID }, playerMoveItem);
        }

        // DELETE: api/PlayerMoveItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerMoveItem(short id)
        {
            var playerMoveItem = await _context.PlayerMoves.FindAsync(id);
            if (playerMoveItem == null)
            {
                return NotFound();
            }

            _context.PlayerMoves.Remove(playerMoveItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerMoveItemExists(short id)
        {
            return _context.PlayerMoves.Any(e => e.MoveID == id);
        }
    }
}
