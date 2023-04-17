using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dev33.UltimateTeam.Application.Encyptors
{
    public class AESEncryptor : IEncryptor
    {
        private byte[] key =
        {
            254, 255, 69, 32, 1, 5, 56 , 226, 194, 59, 89, 222, 90, 155, 63, 45,
            30, 104, 31, 119, 52, 93,11, 168, 54, 21, 163, 220, 225, 42 , 44, 196
        };

        private byte[] IV = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

        public string DecryptData(string data)
        {
            byte[] bytes = Convert.FromBase64String(data);
            SymmetricAlgorithm crypt = Aes.Create();
            HashAlgorithm hash = MD5.Create();
            crypt.Key = this.key;
            crypt.IV = IV;

            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, crypt.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    byte[] decryptedBytes = new byte[bytes.Length];
                    cryptoStream.Read(decryptedBytes, 0, decryptedBytes.Length);

                    return Encoding.Unicode.GetString(decryptedBytes).TrimEnd('\0');
                }
            }
        }

        public string EncryptData(string data)
        {
            byte[] AESEncodedBytes = Encoding.Unicode.GetBytes(data);
            SymmetricAlgorithm crypt = Aes.Create();
            HashAlgorithm hash = MD5.Create();
            crypt.BlockSize = 128;
            crypt.Key = this.key;
            crypt.IV = IV;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, crypt.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(AESEncodedBytes, 0, AESEncodedBytes.Length);
                }

                return Convert.ToBase64String(memoryStream.ToArray());
            }
        }
    }
}
