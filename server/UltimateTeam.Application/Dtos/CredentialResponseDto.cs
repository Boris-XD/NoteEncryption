using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev33.UltimateTeam.Application.Dtos
{
    public class CredentialResponseDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<string> Urls { get; set; }
        public string Type { get; set; }
        public string EncryptionType { get; set; }
        public Guid ContainerId { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
        public bool Favorite { get; set; }
        public string Name { get; set; }
    }
}
