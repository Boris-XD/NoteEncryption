using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dev33.UltimateTeam.Domain.Models;

namespace Dev33.UltimateTeam.Application.Contracts.Services
{
    public interface ISearchService
    {
        Task<IEnumerable<Information>> Search(Guid userId, string searchTerm);
    }
}
