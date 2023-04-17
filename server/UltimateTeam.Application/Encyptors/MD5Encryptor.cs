using System;
using System.Security.Cryptography;
using System.Text;

namespace Dev33.UltimateTeam.Application.Encyptors
{
    public class MD5Encryptor : IEncryptor
    {
        public string DecryptData(string data)
        {
            throw new NotImplementedException();
        }

        public string EncryptData(string data)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(data));

            for (int i = 0; i < stream.Length; i++) 
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }
            return sb.ToString();
        }
    }
}