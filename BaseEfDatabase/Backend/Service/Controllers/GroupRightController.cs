using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database.Logic;
using Database.Model.Shared;

namespace Service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GroupRightController : ControllerBase
    {
        private readonly MainDatabaseContext _context;

        public GroupRightController(MainDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/GroupRight
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupRight>>> GetGroupRights()
        {
            return await _context.GroupRights.ToListAsync();
        }

        // GET: api/GroupRight/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupRight>> GetGroupRight(Guid id)
        {
            var groupRight = await _context.GroupRights.FindAsync(id);

            if (groupRight == null)
            {
                return NotFound();
            }

            return groupRight;
        }

        // PUT: api/GroupRight/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupRight(Guid id, GroupRight groupRight)
        {
            if (id != groupRight.GroupRightId)
            {
                return BadRequest();
            }

            _context.Entry(groupRight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupRightExists(id))
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

        // POST: api/GroupRight
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GroupRight>> PostGroupRight(GroupRight groupRight)
        {
            _context.GroupRights.Add(groupRight);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroupRight", new { id = groupRight.GroupRightId }, groupRight);
        }

        // DELETE: api/GroupRight/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GroupRight>> DeleteGroupRight(Guid id)
        {
            var groupRight = await _context.GroupRights.FindAsync(id);
            if (groupRight == null)
            {
                return NotFound();
            }

            _context.GroupRights.Remove(groupRight);
            await _context.SaveChangesAsync();

            return groupRight;
        }

        private bool GroupRightExists(Guid id)
        {
            return _context.GroupRights.Any(e => e.GroupRightId == id);
        }
    }
}
