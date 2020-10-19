using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Database.Logic.Context;
using Backend.Database.Model.Shared.UserManagement;

namespace Backend.Service.Controller.MasterDataController
{
    [Route("[controller]")]
    [ApiController]
    public class UserRightController : ControllerBase
    {
        private readonly MainDatabaseContext _context;

        public UserRightController(MainDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/UserRight
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRight>>> GetUserRights()
        {
            return await _context.UserRights.ToListAsync();
        }

        // GET: api/UserRight/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRight>> GetUserRight(Guid id)
        {
            var userRight = await _context.UserRights.FindAsync(id);

            if (userRight == null)
            {
                return NotFound();
            }

            return userRight;
        }

        // PUT: api/UserRight/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserRight(Guid id, UserRight userRight)
        {
            if (id != userRight.UserRightId)
            {
                return BadRequest();
            }

            _context.Entry(userRight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRightExists(id))
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

        // POST: api/UserRight
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserRight>> PostUserRight(UserRight userRight)
        {
            _context.UserRights.Add(userRight);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserRight", new { id = userRight.UserRightId }, userRight);
        }

        // DELETE: api/UserRight/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserRight>> DeleteUserRight(Guid id)
        {
            var userRight = await _context.UserRights.FindAsync(id);
            if (userRight == null)
            {
                return NotFound();
            }

            _context.UserRights.Remove(userRight);
            await _context.SaveChangesAsync();

            return userRight;
        }

        private bool UserRightExists(Guid id)
        {
            return _context.UserRights.Any(e => e.UserRightId == id);
        }
    }
}
