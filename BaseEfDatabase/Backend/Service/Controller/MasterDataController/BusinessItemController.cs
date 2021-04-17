using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Database.Logic.Context;
using Backend.Database.Model.Shared.MasterData;

namespace Backend.Service.Controller.MasterDataController
{
    [Route("[controller]")]
    [ApiController]
    public partial class BusinessItemController : ControllerBase
    {
        private readonly MainDatabaseContext context;

        public BusinessItemController(MainDatabaseContext context)
        {
            this.context = context;
        }

        #region get
        // GET: BusinessItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessItem>>> GetBusinessItems()
        {
            return await context.BusinessItems
                .Include(b => b.PersonList)
                .Include(b => b.Address)
                .Include(b => b.Mandator)
                .ToListAsync();
        }

        // GET: BusinessItem/123
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessItem>> GetBusinessItem(Guid id)
        {
            var businessItem = await context.BusinessItems
                .Include(b => b.PersonList)
                .Include(b => b.Address)
                .Include(b => b.Mandator)
                .Where(b => b.BusinessItemId == id).FirstAsync();

            if (businessItem == null)
            {
                return NotFound();
            }

            return businessItem;
        }

        // GET: BusinessItem/TheName
        [HttpGet()]
        [Route("Name/{Name}")]
        public async Task<ActionResult<IEnumerable<BusinessItem>>> GetBusinessItemByName(string name)
        {
            var businessItem = await context.BusinessItems
                .Include(b => b.PersonList)
                .Include(b => b.Address)
                .Include(b => b.Mandator)
                .Where(x => x.Name.Contains(name))
                .ToListAsync();

            if (businessItem == null)
            {
                return NotFound();
            }

            return businessItem;
        }
        #endregion

        #region put
        // PUT: BusinessItem/123
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusinessItem(Guid id, BusinessItem businessItem)
        {
            if (id != businessItem.BusinessItemId)
            {
                return BadRequest();
            }

            context.Entry(businessItem).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
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

        #region post
        // POST: BusinessItem
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BusinessItem>> PostBusinessItem(BusinessItem businessItem)
        {
            context.BusinessItems.Add(businessItem);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetBusinessItem", new { id = businessItem.BusinessItemId }, businessItem);
        }
        #endregion

        #region delete
        // DELETE: BusinessItem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BusinessItem>> DeleteBusinessItem(Guid id)
        {
            var businessItem = await context.BusinessItems.FindAsync(id);
            if (businessItem == null)
            {
                return NotFound();
            }

            context.BusinessItems.Remove(businessItem);
            await context.SaveChangesAsync();

            return businessItem;
        }
        #endregion

        private bool BusinessItemExists(Guid id)
        {
            return context.BusinessItems.Any(e => e.BusinessItemId == id);
        }
    }
}
