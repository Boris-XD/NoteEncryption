using Dev33.UltimateTeam.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev33.UltimateTeam.Application.Contracts.Services
{
    public interface IContactService
    {
        Task<ContactResponseDto> GetContactById(Guid id);
        Task<ContactResponseDto> CreateContact(ContactRequestDto contact);
        Task<ContactResponseDto> UpdateContact(ContactRequestDto contact, Guid id);
        Task<ContactResponseDto> DeleteContact(Guid id);
    }
}
