using System;
using Dev33.UltimateTeam.Application.Encyptors;
using Xunit;

namespace Dev33.UltimateTeam.Tests.EncryptorTests
{
    public class MD5EncryptorTest
    {
        [Fact]
        public void EncryptDataShouldReturnCorrectValueTest()
        {
            // Arrange
            IEncryptor encryptor = new MD5Encryptor();
            var data = "test";

            // Act
            var result = encryptor.EncryptData(data);

            // Assert
            Assert.Equal("098f6bcd4621d373cade4e832627b4f6", result);
        }

        [Fact]
        public void EncryptDataWithNumbersCharactersTest()
        {
            // Arrange
            IEncryptor encryptor = new MD5Encryptor();
            var data = "W0rdP4ssw0rd";

            // Act
            var result = encryptor.EncryptData(data);

            // Assert
            Assert.Equal("ff5b563dde5f9918c8fd8df9727d8a96", result);
        }

        [Fact]
        public void EncryptDataWithSpecialCharactersTest()
        {
            // Arrange
            IEncryptor encryptor = new MD5Encryptor();
            var data = "W0rdP4ssw0rd!@#$%^&*()_+";

            // Act
            var result = encryptor.EncryptData(data);

            // Assert
            Assert.Equal("b641f8e732ef40c1b6c6d4db1b5364a6", result);
        }
    }
}