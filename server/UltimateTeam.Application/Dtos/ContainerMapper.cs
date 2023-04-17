using System;
using Dev33.UltimateTeam.Application.Helpers;
using Dev33.UltimateTeam.Domain;
using Dev33.UltimateTeam.Domain.Models;

namespace UltimateTeam.Application.Dtos
{
    public static class ContainerMapper
    {
        public static ContainerSpecifyResponseDto Map(Container container)
        {
            var containerResponse = new ContainerSpecifyResponseDto
            {
                Id = container.Id,
                Favorite = container.Favorite,
                Name = container.Name,
                Informations = InformationMapper.Map(container.Information)
            };

            return containerResponse;
        }
    }
}