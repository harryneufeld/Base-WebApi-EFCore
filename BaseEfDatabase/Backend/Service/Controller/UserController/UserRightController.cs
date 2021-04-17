using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Database.Context;
using Shared.Model.Entity.UserData;

namespace Backend.Service.Controller.MasterDataController
{
    [Route("[controller]")]
    [ApiController]
    public class UserRightController : ControllerBase
    {
        private readonly MainDatabaseContext context;

        public UserRightController(MainDatabaseContext context)
        {
            this.context = context;
        }

        #region get
        // GET: api/UserRight
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRight>>> GetUserRights()
        {
            return await context.UserRights.ToListAsync();
        }

        // GET: api/UserRight/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRight>> GetUserRight(Guid id)
        {
            var userRight = await context.UserRights.FindAsync(id);

            if (userRight == null)
            {
                return NotFound();
            }

            return userRight;
        }
        #endregion

        #region put
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

            context.Entry(userRight).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
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
        #endregion

        #region post
        // POST: api/UserRight
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserRight>> PostUserRight(UserRight userRight)
        {
            context.UserRights.Add(userRight);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetUserRight", new { id = userRight.UserRightId }, userRight);
        }
        #endregion

        #region delete
        // DELETE: api/UserRight/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserRight>> DeleteUserRight(Guid id)
        {
            var userRight = await context.UserRights.FindAsync(id);
            if (userRight == null)
            {
                return NotFound();
            }

            context.UserRights.Remove(userRight);
            await context.SaveChangesAsync();

            return userRight;
        }
        #endregion

        private bool UserRightExists(Guid id)
        {
            return context.UserRights.Any(e => e.UserRightId == id);
        }
    }
}
