using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Database.Context;
using Shared.Model.Entity.MasterData;
using Microsoft.Extensions.Logging;

namespace Backend.Service.Controller.MasterDataController
{
    [Route("[controller]")]
    [ApiController]
    public class MandatorController : ControllerBase
    {
        private readonly MainDatabaseContext context;
        private readonly ILogger logger;

        public MandatorController(ILogger<MandatorController> logger, MainDatabaseContext context)
        {
            this.context = context;
            this.logger = logger;
        }

        #region get
        // GET: api/Mandator
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mandator>>> GetMandators()
        {
            return await context.Mandators.ToListAsync();
        }

        // GET: api/Mandator/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mandator>> GetMandator(Guid id)
        {
            var mandator = await context.Mandators.FindAsync(id);

            if (mandator == null)
            {
                return NotFound();
            }

            return mandator;
        }
        #endregion

        #region put
        // PUT: api/Mandator/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMandator(Guid id, Mandator mandator)
        {
            if (id != mandator.MandatorId)
            {
                return BadRequest();
            }

            context.Entry(mandator).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MandatorExists(id))
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
        // POST: api/Mandator
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Mandator>> PostMandator(Mandator mandator)
        {
            context.Mandators.Add(mandator);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetMandator", new { id = mandator.MandatorId }, mandator);
        }
        #endregion

        #region delete
        // DELETE: api/Mandator/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mandator>> DeleteMandator(Guid id)
        {
            var mandator = await context.Mandators.FindAsync(id);
            if (mandator == null)
            {
                return NotFound();
            }

            context.Mandators.Remove(mandator);
            await context.SaveChangesAsync();

            return mandator;
        }
        #endregion

        private bool MandatorExists(Guid id)
        {
            return context.Mandators.Any(e => e.MandatorId == id);
        }
    }
}
