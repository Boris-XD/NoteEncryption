using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev33.UltimateTeam.Application.Dtos
{
    public class InformationsSharedResponseDto
    {
        public List<InformationSharedResponseDto> Informations { get; set; } = new List<InformationSharedResponseDto>();
    }
}
