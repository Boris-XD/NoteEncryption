using System;
using Dev33.UltimateTeam.Application.Encyptors;

namespace UltimateTeam.Application.Helpers.Factories
{
    public static class FactoryEncryptor
    {
        public static IEncryptor Create(string encryptionType)
        {
            switch (encryptionType)
            {
                case "Aes":
                    return new AESEncryptor();
                case "Base64":
                    return new Base64Encryptor();
                case "Hex":
                    return new HexadecimalEncryptor();
                case "Binary":
                    return new BinaryEncryptor();
                default:
                    throw new Exception("Invalid encryption type");
            }
        }
    }
}