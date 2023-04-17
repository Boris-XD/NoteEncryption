using System;

namespace UltimateTeam.Application.Dtos
{
    public class InformationResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string InformationType { get; set; }
        public bool Favorite { get; set; }
    }
}