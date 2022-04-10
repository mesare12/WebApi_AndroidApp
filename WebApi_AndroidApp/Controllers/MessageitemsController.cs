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
    public class MessageitemsController : ControllerBase
    {
        private readonly RockPaperScissor _context;

        public MessageitemsController(RockPaperScissor context)
        {
            _context = context;
        }

        // GET: api/Messageitems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Messageitem>>> GetMessage()
        {
            return await _context.Message.ToListAsync();
        }

        // GET: api/Messageitems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Messageitem>> GetMessageitem(long id)
        {
            var messageitem = await _context.Message.FindAsync(id);

            if (messageitem == null)
            {
                return NotFound();
            }

            return messageitem;
        }

        // PUT: api/Messageitems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessageitem(long id, Messageitem messageitem)
        {
            if (id != messageitem.FromUserID)
            {
                return BadRequest();
            }

            _context.Entry(messageitem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageitemExists(id))
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

        // POST: api/Messageitems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Messageitem>> PostMessageitem(Messageitem messageitem)
        {
            _context.Message.Add(messageitem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MessageitemExists(messageitem.FromUserID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMessageitem", new { id = messageitem.FromUserID }, messageitem);
        }

        // DELETE: api/Messageitems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessageitem(long id)
        {
            var messageitem = await _context.Message.FindAsync(id);
            if (messageitem == null)
            {
                return NotFound();
            }

            _context.Message.Remove(messageitem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MessageitemExists(long id)
        {
            return _context.Message.Any(e => e.FromUserID == id);
        }
    }
}
