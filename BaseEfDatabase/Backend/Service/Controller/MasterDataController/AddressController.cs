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
    public class AddressController : ControllerBase
    {
        private readonly MainDatabaseContext context;
        private readonly ILogger logger;

        public AddressController(ILogger<AddressController> logger, MainDatabaseContext context)
        {
            this.context = context;
            this.logger = logger;
        }

        #region get
        // GET: api/Address
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddresses()
        {
            return await this.context.Addresses
                .AsNoTracking()
                .ToListAsync();
        }

        // GET: api/Address/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(Guid id)
        {
            var address = await this.context.Addresses
                .AsNoTracking()
                .Where(x => x.AddressId == id)
                .SingleOrDefaultAsync();

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }
        #endregion

        #region put
        // PUT: api/Address/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(Guid id, Address address)
        {
            if (id != address.AddressId)
            {
                return BadRequest();
            }

            this.context.Entry(address).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
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
        // POST: api/Address
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(Address address)
        {
            this.context.Addresses.Add(address);
            await this.context.SaveChangesAsync();

            return CreatedAtAction("GetAddress", new { id = address.AddressId }, address);
        }
        #endregion

        #region delete
        // DELETE: api/Address/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Address>> DeleteAddress(Guid id)
        {
            var address = await this.context.Addresses.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            this.context.Addresses.Remove(address);
            await this.context.SaveChangesAsync();
            return address;
        }
        #endregion

        private bool AddressExists(Guid id)
            => this.context.Addresses
                .AsNoTracking()
                .Any(e => e.AddressId == id);
    }
}
