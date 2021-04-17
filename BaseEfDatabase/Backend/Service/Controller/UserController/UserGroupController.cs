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
    public class UserGroupController : ControllerBase
    {
        private readonly MainDatabaseContext context;

        public UserGroupController(MainDatabaseContext context)
        {
            this.context = context;
        }

        #region get
        // GET: api/UserGroup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGroup>>> GetUserGroups()
        {
            return await context.UserGroups.ToListAsync();
        }

        // GET: api/UserGroup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserGroup>> GetUserGroup(Guid id)
        {
            var userGroup = await context.UserGroups.FindAsync(id);

            if (userGroup == null)
            {
                return NotFound();
            }

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
            {
                return BadRequest();
            }

            context.Entry(userGroup).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserGroupExists(id))
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
        // POST: api/UserGroup
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserGroup>> PostUserGroup(UserGroup userGroup)
        {
            context.UserGroups.Add(userGroup);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetUserGroup", new { id = userGroup.UserGroupId }, userGroup);
        }
        #endregion

        #region delete
        // DELETE: api/UserGroup/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserGroup>> DeleteUserGroup(Guid id)
        {
            var userGroup = await context.UserGroups.FindAsync(id);
            if (userGroup == null)
            {
                return NotFound();
            }

            context.UserGroups.Remove(userGroup);
            await context.SaveChangesAsync();

            return userGroup;
        }
        #endregion

        private bool UserGroupExists(Guid id)
        {
            return context.UserGroups.Any(e => e.UserGroupId == id);
        }
    }
}
