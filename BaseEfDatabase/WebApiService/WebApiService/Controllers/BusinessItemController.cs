using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database.Logic;
using Database.Model.Shared;

namespace WebApiService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BusinessItemController : ControllerBase
    {
        #region Fields
        private readonly MainDatabaseContext _context;
        #endregion

        #region Contructor
        public BusinessItemController(MainDatabaseContext context)
        {
            _context = context;
        }
        #endregion
        
        #region GetMethods
        // GET: BusinessItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessItem>>> GetBusinessItems()
        {
            return await _context.BusinessItems.ToListAsync();
        }

        // GET: BusinessItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessItem>> GetBusinessItem(Guid id) 
            => await _context.BusinessItems.FindAsync(id);

        // GET: BusinessItem/Name/The_Name
        [HttpGet()]
        [Route("Name/{Name}")]
        public async Task<ActionResult<BusinessItem>> GetBusinessItemByName(string Name)
            => await _context.BusinessItems.FindAsync(_context.BusinessItems.Where(x => x.Name == Name).FirstOrDefault().BusinessItemId);
        #endregion

        #region PutMethods
        // PUT: BusinessItem/5
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
        #endregion

        #region PostMethods
        // POST: BusinessItem
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BusinessItem>> PostBusinessItem(BusinessItem businessItem)
        {
            _context.BusinessItems.Add(businessItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(BusinessItem), new { id = businessItem.BusinessItemId }, businessItem);
        }
        #endregion

        #region DeleteMethods
        // DELETE: BusinessItem/5
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
        #endregion

        private bool BusinessItemExists(Guid id)
        {
            return _context.BusinessItems.Any(e => e.BusinessItemId == id);
        }
    }
}
