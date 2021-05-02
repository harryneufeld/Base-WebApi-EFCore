using Xunit;
using Backend.Database.Context;
using Shared.Model.Entity.MasterData;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace UnitTest.Backend.Database
{
    public class DatabaseTest
    {
        ILoggerFactory logger;

        public DatabaseTest()
        {
            logger = new Mock<ILoggerFactory>().Object;
        }

        [Fact]
        public void AddCompanyTest()
        {            
            bool IsSuccessful;
            var context = new MainDatabaseContext(logger);
            var testItem = new Company();

            var company = new Company()
            {
                Name = "ThisIsATestItem",
                Address = new Address()
                {
                    City = "Bonn",
                    PostalCode = "53117",
                    StreetName = "Pariser Straße",
                    StreetNumber = "14"
                },
            };

            try
            {
                context.Companies.Add(company);
                testItem = context.Companies.Include(x => x.Address).Where(x => x.CompanyId == company.CompanyId).First();
            } catch
            {
                IsSuccessful = false;
            }

            IsSuccessful = (testItem == company);

            if (IsSuccessful)
                context.Companies.Remove(company);

            Assert.True(IsSuccessful);
        }

    }
}