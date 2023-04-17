using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev33.UltimateTeam.Application.Dtos
{
    public class ContactResponseDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Business { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public DateTime Birthday { get; set; }
        public List<string> Emails { get; set; }
        public List<string> Phones { get; set; }
        public List<string> Addresses { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string EncryptionType { get; set; }
        public bool Favorite { get; set; }
        public List<string> Tags { get; set; }
    }
}
