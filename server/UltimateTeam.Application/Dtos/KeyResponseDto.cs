using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev33.UltimateTeam.Application.Dtos
{
    public class KeyResponseDto
    {
        public string Name { get; set; }
        public string Serial { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string EncryptionType { get; set; }
        public bool Favorite { get; set; }
        public List<string> Tags { get; set; }
    }
}
