using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Backend.Database.Context;
using Shared.Model.Entity.MasterData;

namespace Backend.Service.Controller.v1_0.MasterDataController
{
    // TODO: DTOs statt entities verwenden
    // TODO: Authentication hinzufügen
    [ApiVersion("1.0")]
    public class AddressController : BaseApiController
    {
        private readonly MainDatabaseContext context;
        private readonly ILogger logger;

        public AddressController(ILogger<AddressController> logger, MainDatabaseContext context)
        {
            this.context = context;
            this.logger = logger;
        }

        #region get
        // GET: v1/Address
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddresses()
            => await this.context.Addresses
                .AsNoTracking()
                .ToListAsync();

        // GET: v1/Address/5
        [HttpGet("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Address>> GetAddress(Guid id)
        {
            var address = await this.context.Addresses
                .AsNoTracking()
                .Where(x => x.AddressId == id)
                .SingleOrDefaultAsync();
            if (address == null)
                return NotFound();
            return address;
        }
        #endregion

        #region put
        // PUT: v1/Address/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> PutAddress(Guid id, Address address)
        {
            if (id != address.AddressId)
                return BadRequest();
            this.context.Entry(address).State = EntityState.Modified;
            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }
        #endregion

        #region post
        // POST: v1/Address
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Address>> PostAddress(Address address)
        {
            this.context.Addresses.Add(address);
            await this.context.SaveChangesAsync();
            return CreatedAtAction(
                "GetAddress", 
                new { id = address.AddressId }, 
                address);
        }
        #endregion

        #region delete
        // DELETE: v1/Address/5
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Address>> DeleteAddress(Guid id)
        {
            var address = await this.context.Addresses.FindAsync(id);
            if (address == null)
                return NotFound();
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
