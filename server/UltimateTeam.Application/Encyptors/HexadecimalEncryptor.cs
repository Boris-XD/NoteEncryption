using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev33.UltimateTeam.Application.Encyptors
{
    public class HexadecimalEncryptor : IEncryptor
    {
        public string DecryptData(string data)
        {
            var bytes = new List<byte>();

            for (int i = 0; i < data.Length; i += 2)
            {
                bytes.Add(Convert.ToByte(data.Substring(i, 2), 16));
            }

            return Encoding.ASCII.GetString(bytes.ToArray());
        }

        public string EncryptData(string data)
        {
            StringBuilder sb = new StringBuilder();
            byte[] hexaEncodedBytes = Encoding.Default.GetBytes(data);
            sb.Append(Convert.ToHexString(hexaEncodedBytes));

            return sb.ToString();
        }
    }
}
