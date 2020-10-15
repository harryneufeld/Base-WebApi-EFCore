using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database.Logic;
using Database.Model.Shared;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessItemController : ControllerBase
    {
        private readonly MainDatabaseContext _context;

        public BusinessItemController(MainDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/BusinessItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessItem>>> GetBusinessItems()
        {
            return await _context.BusinessItems.ToListAsync();
        }

        // GET: api/BusinessItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessItem>> GetBusinessItem(Guid id)
        {
            var businessItem = await _context.BusinessItems.FindAsync(id);

            if (businessItem == null)
            {
                return NotFound();
            }

            return businessItem;
        }

        // PUT: api/BusinessItem/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusinessItem(Guid id, BusinessItem businessItem)
        {
            if (id != businessItem.BusinessItemId)
            {
                return BadRequest();
            }

            _context.Entry(businessItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessItemExists(id))
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

        // POST: api/BusinessItem
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BusinessItem>> PostBusinessItem(BusinessItem businessItem)
        {
            _context.BusinessItems.Add(businessItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusinessItem", new { id = businessItem.BusinessItemId }, businessItem);
        }

        // DELETE: api/BusinessItem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BusinessItem>> DeleteBusinessItem(Guid id)
        {
            var businessItem = await _context.BusinessItems.FindAsync(id);
            if (businessItem == null)
            {
                return NotFound();
            }

            _context.BusinessItems.Remove(businessItem);
            await _context.SaveChangesAsync();

            return businessItem;
        }

        private bool BusinessItemExists(Guid id)
        {
            return _context.BusinessItems.Any(e => e.BusinessItemId == id);
        }
    }
}
