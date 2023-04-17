using Dev33.UltimateTeam.Domain.Models;
using System;
using System.Collections.Generic;

namespace UltimateTeam.Application.Helpers
{
    public static class PhoneMapper
    {
        internal static List<Phone> Map(string phones, Guid id)
        {
            var phoneList = new List<Phone>();

            if (string.IsNullOrEmpty(phones))
            {
                return phoneList;
            }

            var phoneArray = phones.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var phone in phoneArray)
            {
                phoneList.Add(new Phone
                {
                    ContactId = id,
                    Number = phone
                });
            }

            return phoneList;
        }

        public static List<string> Map(List<Phone> phones)
        {
            var phoneList = new List<string>();

            foreach (var phone in phones)
            {
                phoneList.Add(phone.Number);
            }

            return phoneList;
        }
    }
}