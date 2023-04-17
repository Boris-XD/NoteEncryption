using System;
using System.Threading.Tasks;
using Dev33.UltimateTeam.Application.Dtos;
using UltimateTeam.Application.Dtos;

namespace UltimateTeam.Application.Contracts.Services
{
    public interface ICreditCardService
    {
        Task<CreditCardResponseDto> GetCreditCardById(Guid id);
        Task<CreditCardResponseDto> CreateCard(CreditCardRequestDto creditCard);
        Task<CreditCardResponseDto> UpdateCard(CreditCardRequestDto creditCard, Guid id);
        Task<CreditCardResponseDto> DeleteCard(Guid id);
    }
}