using Xunit;
using Dev33.UltimateTeam.Application.Encyptors;

namespace UltimateTeam.Tests.EncryptorTests
{
    public class HexadecimalEncryptorTest
    {
        [Fact]
        public void EncryptDataShouldReturnCorrectValueTest()
        {
            IEncryptor encryptor = new HexadecimalEncryptor();
            var data = "test";
            var result = encryptor.EncryptData(data);

            Assert.Equal("74657374", result);
        }

        [Fact]
        public void EncryptDataWithSpecialCharactersTest()
        {
            IEncryptor encryptor = new HexadecimalEncryptor();
            var data = "Word$@p4ssWor6";

            var result = encryptor.EncryptData(data);

            Assert.Equal("576F7264244070347373576F7236", result);
        }

        [Fact]
        public void DecryptDataShouldReturnCorrectValueTest()
        {
            IEncryptor encryptor = new HexadecimalEncryptor();
            string codeCypher = "74657374";

            Assert.Equal("test", encryptor.DecryptData(codeCypher));
        }

        [Fact]
        public void DecryptDataWithSpecialCharactersTest()
        {
            IEncryptor encryptor = new HexadecimalEncryptor();
            string codeCypher = "576F7264244070347373576F7236";

            Assert.Equal("Word$@p4ssWor6", encryptor.DecryptData(codeCypher));
        }
    }
}