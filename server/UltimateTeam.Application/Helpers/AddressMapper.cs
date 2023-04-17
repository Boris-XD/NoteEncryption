
using Dev33.UltimateTeam.Domain.Models;
using System;
using System.Collections.Generic;

namespace UltimateTeam.Application.Helpers
{
    public static class AddressMapper
    {
        public static List<Address> Map(string addresses, Guid id)
        {
            var addressList = new List<Address>();

            if (string.IsNullOrEmpty(addresses))
            {
                return addressList;
            }

            var addressArray = addresses.Split('/');

            foreach (var address in addressArray)
            {
                addressList.Add(new Address
                {
                    ContactId = id,
                    Location = address
                });
            }

            return addressList;
        }

        public static List<string> Map(List<Address> addresses)
        {
            var addressList = new List<string>();

            foreach (var address in addresses)
            {
                addressList.Add(address.Location);
            }

            return addressList;
        }
    }
}