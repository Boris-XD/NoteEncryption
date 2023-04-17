using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev33.UltimateTeam.Application.Dtos
{
    public class CreditCardResponseDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Issuer { get; set; }
        public string Cvv { get; set; }
        public DateTime Expiration { get; set; }        
        public string Type { get; set; }
        public string EncryptionType { get; set; }
        public bool Favorite { get; set; }
        public List<string> Tags { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
}
