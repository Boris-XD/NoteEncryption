using Dev33.UltimateTeam.Application.Encyptors;
using Dev33.UltimateTeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dev33.UltimateTeam.Application.Helpers
{
    public static class HandleEncryption
    {
        public static object HandleEncryptData(object information, IEncryptor encryptor, bool encrypt)
        {
            var properties = information.GetType().GetProperties();

            foreach (var property in properties)
            {
                if (property.PropertyType.IsGenericType)
                {
                    var list = HandleEncryptList(property, encryptor, encrypt, information);
                    property.SetValue(information, list);
                }

                if ((property.GetCustomAttributes<DisplayAttribute>()?.FirstOrDefault()?.Encrypted == true))
                {
                    var value = property.GetValue(information);
                    var valueEncrypted = encrypt ? encryptor.EncryptData(value.ToString()) : encryptor.DecryptData(value.ToString());
                    property.SetValue(information, valueEncrypted);
                }
            }

            return information;
        }

        private static object HandleEncryptList(PropertyInfo property, IEncryptor encryptor, bool encrypt, object information)
        {
            var list = property.GetValue(information);
            var response = new List<object>();

            foreach (var item in list as IEnumerable<object>)
            {
                var itemResponse = HandleEncryptData(item, encryptor, encrypt);
                response.Add(itemResponse);
            }

            return list;
        }
    }
}
