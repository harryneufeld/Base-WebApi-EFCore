using NUnit.Framework;
using Microsoft.Extensions.Options;
using Backend.Logic.Helper.Password;

namespace UnitTest.Backend.Logic
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PassowrdHasherTest()
        {
            var hasher = new PasswordHasher(Options.Create(new HashingOptions()));
            string password = "Thd35%wddjhd56!?";
            string hash = hasher.Hash(password);
            Assert.IsTrue(hasher.Check(hasher.Hash(password), password).Verified);
        }
    }
}