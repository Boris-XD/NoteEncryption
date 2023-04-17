using Dev33.UltimateTeam.Application.Encyptors;
using Xunit;

namespace UltimateTeam.Tests.EncryptorTests
{
    public class Base64EncryptorTest
    {
        [Fact]
        public void EncryptDataShouldReturnCorrectValueTest()
        {
            IEncryptor encryptor = new Base64Encryptor();
            var data = "test";

            var result = encryptor.EncryptData(data);

            Assert.Equal("dGVzdA==", result);
        }

        [Fact]
        public void EncryptDataWithSpecialCharactersTest()
        {
            IEncryptor encryptor = new Base64Encryptor();
            var data = "Word$@p4ssWor6";

            var result = encryptor.EncryptData(data);

            Assert.Equal("V29yZCRAcDRzc1dvcjY=", result);
        }

        [Fact]
        public void DecryptDataShouldReturnCorrectValueTest()
        {
            IEncryptor encryptor = new Base64Encryptor();
            string codeCypher = "dGVzdA==";

            Assert.Equal("test", encryptor.DecryptData(codeCypher));
        }

        [Fact]
        public void DecryptDataWithSpecialCharactersTest()
        {
            IEncryptor encryptor = new Base64Encryptor();
            string codeCypher = "V29yZCRAcDRzc1dvcjY=";

            Assert.Equal("Word$@p4ssWor6", encryptor.DecryptData(codeCypher));
        }
    }
}