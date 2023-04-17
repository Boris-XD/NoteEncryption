using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev33.UltimateTeam.Application.Dtos
{
    public class ContainerRequestDto
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public bool Favorite { get; set; }
    }
}
