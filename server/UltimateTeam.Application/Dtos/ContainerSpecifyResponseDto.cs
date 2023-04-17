using System;
using System.Collections.Generic;

namespace UltimateTeam.Application.Dtos
{
    public class ContainerSpecifyResponseDto
    {
        public Guid Id { get; set; }
        public bool Favorite { get; set; }
        public string Name { get; set; }
        public List<InformationResponseDto> Informations { get; set; } = new List<InformationResponseDto>();
    }
}