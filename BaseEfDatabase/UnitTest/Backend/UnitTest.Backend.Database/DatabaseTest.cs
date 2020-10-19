using NUnit.Framework;
using Backend.Database.Logic.Context;
using Backend.Database.Model.Shared.MasterData;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            bool IsSuccessful;
            var context = new MainDatabaseContext();
            var testItem = new BusinessItem();

            var businessItem = new BusinessItem()
            {
                BusinessItemId = new System.Guid(),
                Name = "ThisIsATestItem",
                Address = new Address()
                {
                    AddressId = new System.Guid(),
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