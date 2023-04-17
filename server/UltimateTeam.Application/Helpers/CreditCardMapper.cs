using System;
using Dev33.UltimateTeam.Application.Dtos;
using Dev33.UltimateTeam.Domain.Models;
using UltimateTeam.Application.Dtos;

namespace UltimateTeam.Application.Helpers
{
    public static class CreditCardMapper
    {
        public static CreditCard Map(CreditCardRequestDto creditCard, Guid id)
        {
            return new CreditCard
            {
                InformationsId = id,
                Number = creditCard.Number,
                Issuer = creditCard.Issuer,
                Cvv = creditCard.Cvv,
                Expiration = creditCard.Expiration,
                Name = creditCard.CardName,
            };
        }

        public static CreditCardResponseDto Map(CreditCard creditCard, Information information)
        {
            return new CreditCardResponseDto
            {
                Id = creditCard.InformationsId,
                Number = creditCard.Number,
                Issuer = creditCard.Issuer,
                Cvv = creditCard.Cvv,
                Expiration = (DateTime)creditCard.Expiration,
                Favorite = information.Favorite,
                Name = information.Name,
                EncryptionType = information.EncryptionType.ToString(),
                Type = information.Type.ToString(),
                Description = information.Description,
                Tags = TagMapper.Map(information.Tags)
            };
        }
    }
}