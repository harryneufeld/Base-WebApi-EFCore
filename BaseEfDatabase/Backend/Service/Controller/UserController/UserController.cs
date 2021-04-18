using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Database.Context;
using Shared.Model.Entity.UserData;
using Microsoft.Extensions.Logging;

namespace Backend.Service.Controller.MasterDataController
{
    // TODO: DTOs statt entities verwenden
    // TODO: Authentication hinzufügen
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MainDatabaseContext context;
        private readonly ILogger logger;

        public UserController(ILogger<UserController> logger, MainDatabaseContext context)
        {
            this.context = context;
            this.logger = logger;
        }

        #region get
        // GET: User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
            => await this.context.Users
                .AsNoTracking()
                .ToListAsync();

        // GET: User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var user = await this.context.Users.FindAsync(id);
            if (user == null)
                return NotFound();
            
            return user;
        }

        // GET: Name/TheName
        [HttpGet()]
        [Route("Name/{Name}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserByName(string name)
        {
            var userList = await this.context
                .Users
                .AsNoTracking()
                .Where(u => 
                    u.Name.Contains(name) || 
                    u.LastName
                .Contains(name))
                .ToListAsync();

            if (userList == null)
                return NotFound();

            return userList;
        }

        // GET: User/Mail/TheMail
        [HttpGet()]
        [Route("Mail/{MailAddress}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserByMail(string mailAddress)
        {
            var userList = await this.context.Users.Where(u => u.MailAddress == mailAddress).ToListAsync();

            if (userList == null)
                return NotFound();

            return userList;
        }
        #endregion

        #region put
        // PUT: User/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, User user)
        {
            if (id != user.UserId)
                return BadRequest();

            this.context.Entry(user).State = EntityState.Modified;
            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }
        #endregion

        #region post
        // POST: User
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            this.context.Users.Add(user);
            await this.context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }
        #endregion

        #region DELETE
        // DELETE: User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(Guid id)
        {
            var user = await this.context.Users.FindAsync(id);
            if (user == null)
                return NotFound();
            this.context.Users.Remove(user);
            await this.context.SaveChangesAsync();
            return user;
        }
        #endregion

        private bool UserExists(Guid id)
            => this.context.Users
                .AsNoTracking()
                .Any(e => e.UserId == id);
    }
}
