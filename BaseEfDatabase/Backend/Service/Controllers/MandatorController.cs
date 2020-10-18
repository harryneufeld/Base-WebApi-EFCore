using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Database.Logic.Context;
using Backend.Database.Model.Shared.MasterData;

namespace Service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MandatorController : ControllerBase
    {
        private readonly MainDatabaseContext _context;

        public MandatorController(MainDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Mandator
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mandator>>> GetMandators()
        {
            return await _context.Mandators.ToListAsync();
        }

        // GET: api/Mandator/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mandator>> GetMandator(Guid id)
        {
            var mandator = await _context.Mandators.FindAsync(id);

            if (mandator == null)
            {
                return NotFound();
            }

            return mandator;
        }

        // PUT: api/Mandator/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMandator(Guid id, Mandator mandator)
        {
            if (id != mandator.MandatorId)
            {
                return BadRequest();
            }

            _context.Entry(mandator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MandatorExists(id))
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

        // POST: api/Mandator
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Mandator>> PostMandator(Mandator mandator)
        {
            _context.Mandators.Add(mandator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMandator", new { id = mandator.MandatorId }, mandator);
        }

        // DELETE: api/Mandator/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mandator>> DeleteMandator(Guid id)
        {
            var mandator = await _context.Mandators.FindAsync(id);
            if (mandator == null)
            {
                return NotFound();
            }

            _context.Mandators.Remove(mandator);
            await _context.SaveChangesAsync();

            return mandator;
        }

        private bool MandatorExists(Guid id)
        {
            return _context.Mandators.Any(e => e.MandatorId == id);
        }
    }
}
