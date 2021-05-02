using Xunit;
using Backend.Database.Context;
using Shared.Model.Entity.MasterData;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Microsoft.Extensions.DependencyInjection;
using FluentAssertions;

namespace UnitTest.Database
{
    public class DatabaseTest
    {
        ILoggerFactory factory;
        MainDatabaseContext context;

        public DatabaseTest()
        {
            //var serviceProvider = new ServiceCollection()
            //    .AddLogging()
            //    .BuildServiceProvider();

            this.factory = new Microsoft.Extensions.Logging.Abstractions.NullLoggerFactory();
        }

        [Fact]
        public async void AddCompanyTest()
        {            
            this.context = new MainDatabaseContext(this.factory);
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

            this.context.Companies.Add(company);
            await this.context.SaveChangesAsync();
            testItem = await this.context.Companies
                .Include(x => x.Address)
                .Where(x => x.CompanyId == company.CompanyId)
                .FirstOrDefaultAsync();
 
            testItem.Name.Should()
                .Be(company.Name);
            testItem.Address.City.Should()
                .Be(company.Address.City);
            testItem.Address.PostalCode.Should()
                .Be(company.Address.PostalCode);
            testItem.Address.StreetName.Should()
                .Be(company.Address.StreetName);
            testItem.Address.StreetNumber.Should()
                .Be(company.Address.StreetNumber);
            //Assert.True(IsSuccessful);
        }

    }
}