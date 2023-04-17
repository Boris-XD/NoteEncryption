using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev33.UltimateTeam.Application.Dtos
{
    public class ContactRequestDto
    {
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Business { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public DateTime Birthday { get; set; }
        public string Emails { get; set; }
        public string Phones { get; set; }
        public string Addresses { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string EncryptionType { get; set; }
        public bool Favorite { get; set; }
        public string Tags { get; set; }
        public Guid ContainerId { get; set; }
    }
}
