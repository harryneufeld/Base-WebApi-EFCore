using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Database.Logic.Context;
using Backend.Database.Model.Shared.UserManagement;

namespace Service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserGroupRightController : ControllerBase
    {
        private readonly MainDatabaseContext _context;

        public UserGroupRightController(MainDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/UserGroupRight
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGroupRight>>> GetUserGroupRights()
        {
            return await _context.UserGroupRights.ToListAsync();
        }

        // GET: api/UserGroupRight/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserGroupRight>> GetUserGroupRight(Guid id)
        {
            var UserGroupRight = await _context.UserGroupRights.FindAsync(id);

            if (UserGroupRight == null)
            {
                return NotFound();
            }

            return UserGroupRight;
        }

        // PUT: api/UserGroupRight/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserGroupRight(Guid id, UserGroupRight UserGroupRight)
        {
            if (id != UserGroupRight.UserGroupRightId)
            {
                return BadRequest();
            }

            _context.Entry(UserGroupRight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserGroupRightExists(id))
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

        // POST: api/UserGroupRight
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserGroupRight>> PostUserGroupRight(UserGroupRight UserGroupRight)
        {
            _context.UserGroupRights.Add(UserGroupRight);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserGroupRight", new { id = UserGroupRight.UserGroupRightId }, UserGroupRight);
        }

        // DELETE: api/UserGroupRight/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserGroupRight>> DeleteUserGroupRight(Guid id)
        {
            var UserGroupRight = await _context.UserGroupRights.FindAsync(id);
            if (UserGroupRight == null)
            {
                return NotFound();
            }

            _context.UserGroupRights.Remove(UserGroupRight);
            await _context.SaveChangesAsync();

            return UserGroupRight;
        }

        private bool UserGroupRightExists(Guid id)
        {
            return _context.UserGroupRights.Any(e => e.UserGroupRightId == id);
        }
    }
}
