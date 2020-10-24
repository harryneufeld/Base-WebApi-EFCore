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
        public void AddBusinessItemTest()
        {
            ILoggerFactory logger = new Mock<ILoggerFactory>().Object;

            bool IsSuccessful;
            var context = new MainDatabaseContext(logger);
            var testItem = new BusinessItem();

            var businessItem = new BusinessItem()
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
                context.BusinessItems.Add(businessItem);
                testItem = context.BusinessItems.Include(x => x.Address).Where(x => x.BusinessItemId == businessItem.BusinessItemId).First();
            } catch
            {
                IsSuccessful = false;
            }

            IsSuccessful = (testItem == businessItem);

            if (IsSuccessful)
                context.BusinessItems.Remove(businessItem);

            Assert.IsTrue(IsSuccessful);
        }

    }
}