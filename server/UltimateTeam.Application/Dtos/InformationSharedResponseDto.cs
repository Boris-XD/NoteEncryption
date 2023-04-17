using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev33.UltimateTeam.Application.Dtos
{
    public class InformationSharedResponseDto
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public Guid InformationId { get; set; }
        public string Name { get; set; }
        public string InformationType { get; set; }
        public bool Favorite { get; set; }
    }
}
