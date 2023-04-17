using Dev33.UltimateTeam.Application.Dtos;
using Dev33.UltimateTeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev33.UltimateTeam.Application.Helpers
{
    public static class SharedInformationMapper
    {
        public static ShareInformation Map(Guid informationId, Guid guessId)
        {
            return new ShareInformation
            {
                InformationId = informationId,
                GuessId = guessId
            };
        }

        public static InformationSharedResponseDto Map(ShareInformation informationShared, User guessExisted, Information information)
        {
            return new InformationSharedResponseDto
            {
                InformationId = informationShared.InformationId,
                Email = guessExisted.Email,
                Username = guessExisted.UserName,
                Name = information.Name,
                Favorite = information.Favorite,
                InformationType = information.Type.ToString(),
            };
        }

        public static List<InformationSharedResponseDto> Map(ICollection<ShareInformation> informationsShared)
        {
            var informationsSharedResponseDto = new List<InformationSharedResponseDto>();

            foreach (var shared in informationsShared)
            {
                var information = shared.Information;
                var guessExisted = shared.Guess;
                var owner = information.Container.User;
            }

            return informationsSharedResponseDto;
        }
    }
}
