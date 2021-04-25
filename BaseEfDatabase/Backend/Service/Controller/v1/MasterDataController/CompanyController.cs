using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Web.Http;
using Backend.Database.Context;
using Shared.Model.Entity.MasterData;

namespace Backend.Service.Controller.MasterDataController
{
    // TODO: DTOs statt entities verwenden
    // TODO: Authentication hinzufügen
    [ApiVersion("1.0")]
    public partial class CompanyController : BaseApiController
    {
        private readonly MainDatabaseContext context;
        private readonly ILogger logger;

        public CompanyController(ILogger<CompanyController> logger, MainDatabaseContext context)
        {
            this.context = context;
            this.logger = logger;
        }

        #region get
        // GET: Company
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
            => await this.context.Companies
                .AsNoTracking()
                .Include(b => b.PersonList)
                .Include(b => b.Address)
                .Include(b => b.Mandator)
                .ToListAsync();

        // GET: Company/123
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(Guid id)
        {
            var company = await this.context.Companies
                .AsNoTracking()
                .Include(b => b.PersonList)
                .Include(b => b.Address)
                .Include(b => b.Mandator)
                .Where(b => b.CompanyId == id)
                .FirstAsync();
            if (company == null)
                return NotFound();
            return company;
        }

        // GET: Company/TheName
        [HttpGet()]
        [Route("Name/{Name}")]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanyByName(string name)
        {
            var company = await this.context.Companies
                .AsNoTracking()
                .Include(b => b.PersonList)
                .Include(b => b.Address)
                .Include(b => b.Mandator)
                .Where(x => x.Name.Contains(name))
                .ToListAsync();
            if (company == null)
                return NotFound();
            return company;
        }
        #endregion

        #region put
        // PUT: Company/123
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(Guid id, Company company)
        {
            if (id != company.CompanyId)
                return BadRequest();
            try
            {
                this.context.Entry(company).State = EntityState.Modified;
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }
        #endregion

        #region post
        // POST: Company
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany(Company company)
        {
            try
            {
                this.context.Companies.Add(company);
                await this.context.SaveChangesAsync();
            } catch (Exception e)
            {
                this.logger.LogError(e,$"POST: PostCompany: '{company.Name}' with Id '{company.CompanyId}'");
            }
            return CreatedAtAction("GetCompany", new { id = company.CompanyId }, company);
        }
        #endregion

        #region delete
        // DELETE: Company/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Company>> DeleteCompany(Guid id)
        {
            var company = await this.context.Companies.FindAsync(id);
            if (company == null)
                return NotFound();
            this.context.Companies.Remove(company);
            await this.context.SaveChangesAsync();
            return company;
        }
        #endregion

        private bool CompanyExists(Guid id)
            => this.context.Companies
                .AsNoTracking()
                .Any(e => e.CompanyId == id);
    }
}
