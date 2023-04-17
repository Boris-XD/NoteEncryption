using System;
using System.Threading.Tasks;
using Dev33.UltimateTeam.Application.Dtos;

namespace UltimateTeam.Application.Contracts.Services
{
    public interface ICredentialService
    {
        Task<CredentialResponseDto> GetCredentialById(Guid id);
        Task<CredentialResponseDto> CreateCredential(CredentialRequestDto credentialRequestDto);
        Task<CredentialResponseDto> UpdateCredential(CredentialRequestDto credentialRequestDto, Guid id);
        Task<CredentialResponseDto> DeleteCredential(Guid id);
    }
}