using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Backend.Database.Context;
using Shared.Model.Entity.MasterData;

namespace Backend.Service.Controller.MasterDataController
{
    // TODO: DTOs statt entities verwenden
    // TODO: Authentication hinzufügen
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
            => await this.context.Mandators
                .AsNoTracking()
                .ToListAsync();

        // GET: api/Mandator/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mandator>> GetMandator(Guid id)
        {
            var mandator = await this.context.Mandators
                .AsNoTracking()
                .Where(x => x.MandatorId == id)
                .SingleOrDefaultAsync();
            if (mandator == null)
                return NotFound();
            return mandator;
        }
        #endregion

        #region put
        // PUT: api/Mandator/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMandator(Mandator mandator)
        {
            this.context.Entry(mandator).State = EntityState.Modified;
            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.MandatorExists(mandator.MandatorId))
                    return NotFound();
                else
                    throw;
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
            this.context.Mandators.Add(mandator);
            await this.context.SaveChangesAsync();
            return CreatedAtAction(
                "GetMandator", 
                new { id = mandator.MandatorId }, 
                mandator);
        }
        #endregion

        #region delete
        // DELETE: api/Mandator/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mandator>> DeleteMandator(Guid id)
        {
            var mandator = await this.context.Mandators.FindAsync(id);
            if (mandator == null)
                return NotFound();
            this.context.Mandators.Remove(mandator);
            await this.context.SaveChangesAsync();
            return mandator;
        }
        #endregion

        private bool MandatorExists(Guid id)
            => this.context.Mandators
                .AsNoTracking()
                .Any(e => e.MandatorId == id);
    }
}
