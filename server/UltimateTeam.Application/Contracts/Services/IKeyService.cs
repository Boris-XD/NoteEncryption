using Dev33.UltimateTeam.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev33.UltimateTeam.Application.Contracts.Services
{
    public interface IKeyService
    {
        Task<KeyResponseDto> GetKeyById(Guid id);
        Task<KeyResponseDto> CreateKey(KeyRequestDto key);
        Task<KeyResponseDto> UpdateKey(KeyRequestDto key, Guid keyId);
        Task<KeyResponseDto> DeleteKey(Guid id);
    }
}
