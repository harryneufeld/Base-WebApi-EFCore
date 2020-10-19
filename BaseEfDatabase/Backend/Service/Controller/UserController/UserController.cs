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
    public class UserController : ControllerBase
    {
        private readonly MainDatabaseContext _context;

        public UserController(MainDatabaseContext context)
        {
            _context = context;
        }

        #region GET
        // GET: User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // GET: Name/TheName
        [HttpGet()]
        [Route("Name/{Name}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserByName(string name)
        {
            var userList = await _context.Users.Where(u => u.Name.Contains(name) || u.LastName.Contains(name)).ToListAsync();

            if (userList == null)
            {
                return NotFound();
            }

            return userList;
        }

        // GET: User/Mail/TheMail
        [HttpGet()]
        [Route("Mail/{MailAddress}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserByMail(string mailAddress)
        {
            var userList = await _context.Users.Where(u => u.MailAddress == mailAddress).ToListAsync();

            if (userList == null)
            {
                return NotFound();
            }

            return userList;
        }
        #endregion

        #region PUT
        // PUT: User/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        #region POST
        // POST: User
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }
        #endregion

        #region DELETE
        // DELETE: User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }
        #endregion

        #region Private Methods
        private bool UserExists(Guid id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
        #endregion
    }
}
