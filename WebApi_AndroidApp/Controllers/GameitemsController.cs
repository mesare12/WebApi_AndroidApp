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
    public class GameitemsController : ControllerBase
    {
        private readonly RockPaperScissor _context;

        public GameitemsController(RockPaperScissor context)
        {
            _context = context;
        }

        // GET: api/Gameitems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gameitem>>> GetGame()
        {
            return await _context.Game.ToListAsync();
        }

        // GET: api/Gameitems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gameitem>> GetGameitem(long id)
        {
            var gameitem = await _context.Game.FindAsync(id);

            if (gameitem == null)
            {
                return NotFound();
            }

            return gameitem;
        }

        // PUT: api/Gameitems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameitem(long id, Gameitem gameitem)
        {
            if (id != gameitem.PlayerOneID)
            {
                return BadRequest();
            }

            _context.Entry(gameitem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameitemExists(id))
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

        // POST: api/Gameitems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gameitem>> PostGameitem(Gameitem gameitem)
        {
            _context.Game.Add(gameitem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GameitemExists(gameitem.PlayerOneID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGameitem", new { id = gameitem.PlayerOneID }, gameitem);
        }

        // DELETE: api/Gameitems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameitem(long id)
        {
            var gameitem = await _context.Game.FindAsync(id);
            if (gameitem == null)
            {
                return NotFound();
            }

            _context.Game.Remove(gameitem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GameitemExists(long id)
        {
            return _context.Game.Any(e => e.PlayerOneID == id);
        }
    }
}
