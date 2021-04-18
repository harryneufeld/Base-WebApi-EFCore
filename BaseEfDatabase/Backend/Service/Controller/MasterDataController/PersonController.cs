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
    [Route("[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
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
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
            => await this.context.Persons
                .AsNoTracking()
                .Include(p => p.Address)
                .Include(p => p.BusinessItem)
                .ToListAsync();

        // GET: Person/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(Guid id)
        {
            var person = await this.context.Persons
                .AsNoTracking()
                .Include(p => p.Address)
                .Include(p => p.BusinessItem)
                .Where(p => p.PersonId == id)
                .SingleOrDefaultAsync();

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        // GET: Person/Name/TheName
        [HttpGet()]
        [Route("Name/{Name}")]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersonByName(string name)
        {
            var personList = await this.context.Persons
                .AsNoTracking()
                .Include(p => p.Address)
                .Include(p => p.BusinessItem)
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
        public async Task<ActionResult<IEnumerable<Person>>> GetPersonByMail(string mailAddress)
        {
            var personList = await this.context.Persons
                .AsNoTracking()
                .Include(p => p.Address)
                .Include(p => p.BusinessItem)
                .Where(p =>
                    p.Mail == mailAddress)
                .ToListAsync();

            if (personList == null)
                return NotFound();
            return personList;
        }
        #endregion

        #region put
        // PUT: Person/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(Guid id, Person person)
        {
            if (id != person.PersonId)
            {
                return BadRequest();
            }

            this.context.Entry(person).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
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
        // POST: Person
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            this.context.Persons.Add(person);
            await this.context.SaveChangesAsync();
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
            {
                return NotFound();
            }

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
