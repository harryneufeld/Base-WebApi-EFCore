using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Database.Context;
using Shared.Model.Entity.UserData;
using Microsoft.Extensions.Logging;

namespace Backend.Service.Controller.v1_0.UserController
{
    // TODO: DTOs statt entities verwenden
    // TODO: Authentication hinzufügen
    [ApiVersion("1.0")]
    public class UserGroupController : BaseApiController
    {
        private readonly MainDatabaseContext context;
        private readonly ILogger logger;

        public UserGroupController(ILogger<UserGroupController> logger, MainDatabaseContext context)
        {
            this.context = context;
            this.logger = logger;
        }

        #region get
        // GET: api/UserGroup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGroup>>> GetUserGroups()
            => await this.context.UserGroups
                .AsNoTracking()
                .ToListAsync();

        // GET: api/UserGroup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserGroup>> GetUserGroup(Guid id)
        {
            var userGroup = await this.context.UserGroups
                .AsNoTracking()
                .Where(x => x.UserGroupId == id)
                .SingleOrDefaultAsync();
            if (userGroup == null)
                return NotFound();
            return userGroup;
        }
        #endregion

        #region put
        // PUT: api/UserGroup/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserGroup(Guid id, UserGroup userGroup)
        {
            if (id != userGroup.UserGroupId)
                return BadRequest();
            this.context.Entry(userGroup).State = EntityState.Modified;
            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserGroupExists(id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }
        #endregion

        #region post
        // POST: api/UserGroup
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserGroup>> PostUserGroup(UserGroup userGroup)
        {
            this.context.UserGroups.Add(userGroup);
            await this.context.SaveChangesAsync();
            return CreatedAtAction(
                "GetUserGroup", 
                new { id = userGroup.UserGroupId }, 
                userGroup);
        }
        #endregion

        #region delete
        // DELETE: api/UserGroup/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserGroup>> DeleteUserGroup(Guid id)
        {
            var userGroup = await this.context.UserGroups.FindAsync(id);
            if (userGroup == null)
                return NotFound();
            this.context.UserGroups.Remove(userGroup);
            await this.context.SaveChangesAsync();
            return userGroup;
        }
        #endregion

        private bool UserGroupExists(Guid id)
            => this.context.UserGroups
                .AsNoTracking()
                .Any(e => e.UserGroupId == id);
    }
}
