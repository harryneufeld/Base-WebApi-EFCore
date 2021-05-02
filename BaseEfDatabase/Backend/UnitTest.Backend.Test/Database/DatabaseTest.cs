using Xunit;
using Backend.Database.Context;
using Shared.Model.Entity.MasterData;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Microsoft.Extensions.DependencyInjection;

namespace UnitTest.Database
{
    public class DatabaseTest
    {
        ILoggerFactory factory;

        public DatabaseTest()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<Company>();
        }

        [Fact]
        public void AddCompanyTest()
        {            
            bool IsSuccessful;
            var context = new MainDatabaseContext(this.factory);
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
                testItem = context.Companies
                    .Include(x => x.Address)
                    .Where(x => x.CompanyId == company.CompanyId)
                    .First();
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