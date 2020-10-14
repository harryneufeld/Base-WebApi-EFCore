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
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        #region Fields
        private readonly MainDatabaseContext _context;
        #endregion

        #region Contructor
        public AddressController(MainDatabaseContext context)
        {
            _context = context;
        }
        #endregion

        #region GetMethods
        // GET: Address
        [HttpGet]
        [Route("All")]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddresses()
        {
            return await _context.Addresses.ToListAsync();
        }

        // GET: Address/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(Guid id)
            => await _context.Addresses.FindAsync(id);

        // GET: Address/Name/Streetname
        [HttpGet()]
        [Route("Name/{StreetName}")]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddressesByName(string streetName)
            => await _context.Addresses.Where(x => x.StreetName.Contains(streetName)).ToListAsync();
        #endregion

        #region PutMethods
        // PUT: Address/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(Guid id, Address address)
        {
            if (id != address.AddressId)
            {
                return BadRequest();
            }

            _context.Entry(address).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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

        #region PostMethods
        // POST: Address
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(Address address)
        {
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Address), new { id = address.AddressId }, address);
        }
        #endregion

        #region DeleteMethods
        // DELETE: Address/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Address>> DeleteAddressById(Guid id)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();

            return address;
        }

        // DELETE: BusinessItem/StreetName
        [HttpDelete()]
        [Route("StreetName/{StreetName}")]
        public async Task<ActionResult<IEnumerable<Address>>> DeleteAddressesByStreetName(string streetName)
        {
            var addresses = _context.Addresses.Where(x => x.StreetName.Contains(streetName)).ToListAsync();
            if (addresses == null)
            {
                return NotFound();
            }

            _context.Addresses.RemoveRange(addresses.Result);

            await _context.SaveChangesAsync();

            return addresses.Result;
        }

        // DELETE: BusinessItem/All
        [HttpDelete("All")]
        public async Task<ActionResult<IEnumerable<Address>>> DeleteAddressesAll()
        {
            var address = _context.Addresses;
            if (address == null)
            {
                return NotFound();
            }

            _context.Addresses.RemoveRange(address);

            await _context.SaveChangesAsync();

            return address;
        }
        #endregion

        private bool AddressExists(Guid id)
        {
            return _context.Addresses.Any(e => e.AddressId == id);
        }
    }
}
