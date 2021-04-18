using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Backend.Database.Context;
using Shared.Model.Entity.MasterData;

namespace Backend.Service.Controller.MasterDataController
{
    // TODO: DTOs statt entities verwenden
    // TODO: Authentication hinzufügen
    [Route("[controller]")]
    [ApiController]
    public partial class BusinessItemController : ControllerBase
    {
        private readonly MainDatabaseContext context;
        private readonly ILogger logger;

        public BusinessItemController(ILogger<BusinessItemController> logger, MainDatabaseContext context)
        {
            this.context = context;
            this.logger = logger;
        }

        #region get
        // GET: BusinessItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessItem>>> GetBusinessItems()
        {
            return await this.context.BusinessItems
                .AsNoTracking()
                .Include(b => b.PersonList)
                .Include(b => b.Address)
                .Include(b => b.Mandator)
                .ToListAsync();
        }

        // GET: BusinessItem/123
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessItem>> GetBusinessItem(Guid id)
        {
            var businessItem = await this.context.BusinessItems
                .AsNoTracking()
                .Include(b => b.PersonList)
                .Include(b => b.Address)
                .Include(b => b.Mandator)
                .Where(b => b.BusinessItemId == id)
                .FirstAsync();

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
            var businessItem = await this.context.BusinessItems
                .AsNoTracking()
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
                return BadRequest();

            try
            {
                this.context.Entry(businessItem).State = EntityState.Modified;
                await this.context.SaveChangesAsync();
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
            try
            {
                this.context.BusinessItems.Add(businessItem);
                await this.context.SaveChangesAsync();
            } catch (Exception e)
            {
                this.logger.LogError(e,$"POST: PostBusinessItem: '{businessItem.Name}' with Id '{businessItem.BusinessItemId}'");
            }

            return CreatedAtAction("GetBusinessItem", new { id = businessItem.BusinessItemId }, businessItem);
        }
        #endregion

        #region delete
        // DELETE: BusinessItem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BusinessItem>> DeleteBusinessItem(Guid id)
        {
            var businessItem = await this.context.BusinessItems.FindAsync(id);
            if (businessItem == null)
            {
                return NotFound();
            }

            this.context.BusinessItems.Remove(businessItem);
            await this.context.SaveChangesAsync();

            return businessItem;
        }
        #endregion

        private bool BusinessItemExists(Guid id)
            => this.context.BusinessItems
                .AsNoTracking()
                .Any(e => e.BusinessItemId == id);
    }
}
