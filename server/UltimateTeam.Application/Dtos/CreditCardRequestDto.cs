using System;

namespace UltimateTeam.Application.Dtos
{
    public class CreditCardRequestDto
    {
        public string Number { get; set; }
        public string Issuer { get; set; }
        public string Cvv { get; set; }
        public DateTime Expiration { get; set; }
        public string Type { get; set; }
        public string EncryptionType { get; set; }
        public bool Favorite { get; set; }
        public string Tags { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        //
        public string CardName { get; set; }
        //
        public Guid ContainerId { get; set; }
    }
}