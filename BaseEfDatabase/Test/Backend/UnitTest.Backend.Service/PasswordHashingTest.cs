using Xunit;
using Microsoft.Extensions.Options;
using Backend.Logic.Helper.Password;

namespace UnitTest.Backend.Logic
{
    public class PasswordHashingTest
    {
        private PasswordHasher hasher;
        private string password = "Thd35%wddjhd56!?";

        public PasswordHashingTest()
        {
            hasher = new PasswordHasher(Options.Create(new HashingOptions()));
        }

        [Fact]
        public void PassowrdHasherTest()
        {
            string hash = hasher.Hash(password);
            Assert.True(hasher.Check(hasher.Hash(password), password).Verified);
        }
    }
}