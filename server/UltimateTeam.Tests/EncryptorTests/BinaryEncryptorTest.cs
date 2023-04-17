using Dev33.UltimateTeam.Application.Encyptors;
using Xunit;

namespace UltimateTeam.Tests.EncryptorTests
{
    public class BinaryEncryptorTest
    {
        [Fact]
        public void EncryptDataShouldReturnCorrectValueTest()
        {
            IEncryptor encryptor = new BinaryEncryptor();
            var data = "test";

            var result = encryptor.EncryptData(data);

            Assert.Equal("01110100011001010111001101110100", result);
        }

        [Fact]
        public void EncryptDataWithSpecialCharactersTest()
        {
            IEncryptor encryptor = new BinaryEncryptor();
            var data = "Word$@p4ssWor6";

            var result = encryptor.EncryptData(data);

            Assert.Equal("0101011101101111011100100110010000100100010000000111000000110100011100110111001101010111011011110111001000110110",
                result);
        }

        [Fact]
        public void DecryptDataShouldReturnCorrectValueTest()
        {
            IEncryptor encryptor = new BinaryEncryptor();
            string codeCypher = "01001000011011110110110001100001001000000110110101110101011011100110010001101111";

            Assert.Equal("Hola mundo", encryptor.DecryptData(codeCypher));
        }

        [Fact]
        public void DecryptDataWithSpecialCharactersTest()
        {
            IEncryptor encryptor = new BinaryEncryptor();
            string codeCypher = "0101011101101111011100100110010000100100010000000111000000110100011100110111001101010111011011110111001000110110";

            Assert.Equal("Word$@p4ssWor6", encryptor.DecryptData(codeCypher));
        }

        [Fact]
        public void DecryptDataWithNumbersCharactersTest()
        {
            IEncryptor encryptor = new BinaryEncryptor();
            string codeCypher = "0101011101101111011100100110010000100100010000000111000000110100011100110111001101010111011011110111001000110110";

            Assert.Equal("Word$@p4ssWor6", encryptor.DecryptData(codeCypher));
        }
    }
}