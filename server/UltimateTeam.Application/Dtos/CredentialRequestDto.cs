using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev33.UltimateTeam.Application.Dtos
{
    public class CredentialRequestDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Urls { get; set; }
        public string Type { get; set; }
        public string EncryptionType { get; set; }
        public Guid ContainerId { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public bool Favorite { get; set; }
        public string Name { get; set; }
    }
}
