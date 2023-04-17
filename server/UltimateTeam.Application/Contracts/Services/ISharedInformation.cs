using Dev33.UltimateTeam.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev33.UltimateTeam.Application.Contracts.Services
{
    public interface ISharedInformation
    {
        Task<InformationSharedResponseDto> ShareInformation(Guid informationId, GuessDto guess);
        Task<InformationsSharedResponseDto> GetInformationsShared(Guid userId);
    }
}
