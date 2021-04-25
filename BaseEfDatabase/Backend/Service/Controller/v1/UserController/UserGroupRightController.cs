using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Web.Http;
using Backend.Database.Context;
using Shared.Model.Entity.UserData;

namespace Backend.Service.Controller.MasterDataController
{
    // TODO: DTOs statt entities verwenden
    // TODO: Authentication hinzufügen
    [ApiVersion("1.0")]
    public class UserGroupRightController : BaseApiController
    {
        private readonly MainDatabaseContext context;
        private readonly ILogger logger;

        public UserGroupRightController(ILogger<UserGroupRightController> logger, MainDatabaseContext context)
        {
            this.context = context;
            this.logger = logger;
        }

        #region get
        // GET: api/UserGroupRight
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGroupRight>>> GetUserGroupRights()
            => await this.context.UserGroupRights
                .AsNoTracking()
                .ToListAsync();

        // GET: api/UserGroupRight/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserGroupRight>> GetUserGroupRight(Guid id)
        {
            var UserGroupRight = await this.context.UserGroupRights
                .AsNoTracking()
                .Where(x => x.UserGroupRightId == id)
                .SingleOrDefaultAsync();
            if (UserGroupRight == null)
                return NotFound();
            return UserGroupRight;
        }
        #endregion

        #region put
        // PUT: api/UserGroupRight/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserGroupRight(Guid id, UserGroupRight UserGroupRight)
        {
            if (id != UserGroupRight.UserGroupRightId)
                return BadRequest();
            this.context.Entry(UserGroupRight).State = EntityState.Modified;
            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserGroupRightExists(id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }
        #endregion

        #region post
        // POST: api/UserGroupRight
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserGroupRight>> PostUserGroupRight(UserGroupRight UserGroupRight)
        {
            this.context.UserGroupRights.Add(UserGroupRight);
            await this.context.SaveChangesAsync();
            return CreatedAtAction(
                "GetUserGroupRight", 
                new { id = UserGroupRight.UserGroupRightId }, 
                UserGroupRight);
        }
        #endregion

        #region delete
        // DELETE: api/UserGroupRight/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserGroupRight>> DeleteUserGroupRight(Guid id)
        {
            var UserGroupRight = await this.context.UserGroupRights.FindAsync(id);
            if (UserGroupRight == null)
                return NotFound();
            this.context.UserGroupRights.Remove(UserGroupRight);
            await this.context.SaveChangesAsync();
            return UserGroupRight;
        }
        #endregion

        private bool UserGroupRightExists(Guid id)
            => this.context.UserGroupRights
                .AsNoTracking()
                .Any(e => e.UserGroupRightId == id);
    }
}
