using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Backend.Database.Context;
using Shared.Model.Entity.MasterData;

namespace Backend.Service.Controller.v1_0.MasterDataController
{
    // TODO: DTOs statt entities verwenden
    // TODO: Authentication hinzufügen
    [ApiVersion("1.0")]
    public class PersonController : BaseApiController
    {
        private readonly MainDatabaseContext context;
        private readonly ILogger logger;

        public PersonController(ILogger<PersonController> logger, MainDatabaseContext context)
        {
            this.context = context;
            this.logger = logger;
        }

        #region get
        // GET: Person
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
            => await this.context.Persons
                .AsNoTracking()
                .Include(p => p.Address)
                .Include(p => p.Company)
                .ToListAsync();

        // GET: Person/5
        [HttpGet("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Person>> GetPerson(Guid id)
        {
            var person = await this.context.Persons
                .AsNoTracking()
                .Include(p => p.Address)
                .Include(p => p.Company)
                .Where(p => p.PersonId == id)
                .SingleOrDefaultAsync();

            if (person == null)
                return NotFound();
            return person;
        }

        // GET: Person/Name/TheName
        [HttpGet()]
        [Route("Name/{Name}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersonByName(string name)
        {
            var personList = await this.context.Persons
                .AsNoTracking()
                .Include(p => p.Address)
                .Include(p => p.Company)
                .Where(p => 
                    p.FirstName.Contains(name) ||
                    p.MiddleName.Contains(name) ||
                    p.LastName.Contains(name))
                .ToListAsync();

            if (personList == null)
                return NotFound();
            return personList;
        }

        // GET: Person/Mail/MailAddress
        [HttpGet()]
        [Route("Mail/{MailAddress}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersonByMail(string mailAddress)
        {
            var personList = await this.context.Persons
                .AsNoTracking()
                .Include(p => p.Address)
                .Include(p => p.Company)
                .Where(p =>
                    p.Mail == mailAddress)
                .ToListAsync();

            if (personList == null)
                return NotFound();
            return personList;
        }
        #endregion

        #region put
        /// <param name="id"></param>
        /// <param name="person"></param>
        /// <returns></returns>
        // PUT: Person/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> PutPerson(Guid id, Person person)
        {
            if (id != person.PersonId)
                return BadRequest();
            this.context.Entry(person).State = EntityState.Modified;
            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }
        #endregion

        #region post
        /// <summary>
        /// Note: Since entities instead of DTOs are still being used, please leave the Ids blank. 
        /// Also posting the Company or the Mandator may not work properly yet.
        /// </summary>
        // POST: Person
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            try
            {
                this.context.Persons.Add(person);
                await this.context.SaveChangesAsync();
            } catch (Exception e)
            {
                this.logger.LogError(e, $"POST: PostPerson: '{person.FirstName} {person.LastName}' with Id '{person.PersonId}'");
            }
            
            return CreatedAtAction("GetPerson", new { id = person.PersonId }, person);
        }
        #endregion

        #region delete
        // DELETE: Person/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> DeletePerson(Guid id)
        {
            var person = await this.context.Persons.FindAsync(id);
            if (person == null)
                return NotFound();
            this.context.Persons.Remove(person);
            await this.context.SaveChangesAsync();
            return person;
        }
        #endregion

        private bool PersonExists(Guid id) 
            => this.context.Persons
                .AsNoTracking()
                .Any(e => e.PersonId == id);
    }
}
