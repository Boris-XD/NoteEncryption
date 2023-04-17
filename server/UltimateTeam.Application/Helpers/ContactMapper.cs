using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dev33.UltimateTeam.Application.Dtos;
using Dev33.UltimateTeam.Domain.Models;
using UltimateTeam.Application.Helpers;

namespace Dev33.UltimateTeam.Application.Helpers
{
    public static class ContactMapper
    {
        public static Contact Map(ContactRequestDto contact, Guid id)
        {
            return new Contact
            {
                InformationsId = id,
                FullName = contact.FullName,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Business = contact.Business,
                Zip = contact.Zip,
                Country = contact.Country,
                State = contact.State,
                Birthday = contact.Birthday,
                Emails = EmailMapper.Map(contact.Emails, id),
                Phones = PhoneMapper.Map(contact.Phones, id),
                Addresses = AddressMapper.Map(contact.Addresses, id),
            };
        }

        public static ContactResponseDto Map(Contact contact, Information information)
        {
            return new ContactResponseDto
            {
                Id = contact.InformationsId,
                FullName = contact.FullName,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Business = contact.Business,
                Zip = contact.Zip,
                Country = contact.Country,
                State = contact.State,
                Birthday = (DateTime)contact.Birthday,
                Emails = EmailMapper.Map((List<Email>)contact.Emails),
                Phones = PhoneMapper.Map((List<Phone>)contact.Phones),
                Addresses = AddressMapper.Map((List<Address>)contact.Addresses),
                Name = information.Name,
                Description = information.Description,
                Favorite = information.Favorite,
                Tags = TagMapper.Map(information.Tags),
                Type = information.Type.ToString(),
                EncryptionType = information.EncryptionType.ToString()
            };
        }
    }
}
