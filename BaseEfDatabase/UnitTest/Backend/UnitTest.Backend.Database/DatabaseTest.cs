using NUnit.Framework;
using Backend.Database.Context;
using Shared.Model.Entity.MasterData;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace UnitTest.Backend.Database
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddCompanyTest()
        {
            ILoggerFactory logger = new Mock<ILoggerFactory>().Object;

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

            Assert.IsTrue(IsSuccessful);
        }

    }
}