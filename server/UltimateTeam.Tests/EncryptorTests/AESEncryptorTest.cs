using Dev33.UltimateTeam.Application.Encyptors;
using Xunit;

namespace UltimateTeam.Tests.EncryptorTests
{
    public class AESEncryptorTest
    {
        [Fact]
        public void EncryptDataShouldReturnCorrectValueTest()
        {
            IEncryptor encryptor = new AESEncryptor();
            var data = "test";

            var result = encryptor.EncryptData(data);

            Assert.Equal("QNKlwbEmJ4hFE2IqRYYQ0w==", result);
        }

        [Fact]
        public void EncryptDataWithSpecialCharactersTest()
        {
            IEncryptor encryptor = new AESEncryptor();
            var data = "Word$@p4ssWor6";

            var result = encryptor.EncryptData(data);

            Assert.Equal("CSVOojvpmfJdM/SjOGt/3IIU3aGHX7jYsAzMnS7mWY4=", result);
        }

        [Fact]
        public void DecryptDataShouldReturnCorrectValueTest()
        {
            IEncryptor encryptor = new AESEncryptor();
            string codeCypher = "QNKlwbEmJ4hFE2IqRYYQ0w==";

            var result = encryptor.DecryptData(codeCypher);

            Assert.Equal("test", result);
        }

        [Fact]
        public void DecryptDataWithSpecialCharactersTest()
        {
            IEncryptor encryptor = new AESEncryptor();
            string codeCypher = "CSVOojvpmfJdM/SjOGt/3IIU3aGHX7jYsAzMnS7mWY4=";

            var result = encryptor.DecryptData(codeCypher);

            Assert.Equal("Word$@p4ssWor6", result);
        }
    }
}