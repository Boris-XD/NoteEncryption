using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev33.UltimateTeam.Application.Encyptors
{
    public class Base64Encryptor : IEncryptor
    {
        public string DecryptData(string data)
        {
            byte[] base64EncodedBytes = Convert.FromBase64String(data);

            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public string EncryptData(string data)
        {
            StringBuilder sb = new StringBuilder();
            byte[] bytesArray = Encoding.Default.GetBytes(data);
            sb.Append(Convert.ToBase64String(bytesArray));

            return sb.ToString();
        }
    }
}
