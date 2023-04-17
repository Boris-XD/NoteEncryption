using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dev33.UltimateTeam.Application.Contracts.Repositories;
using Dev33.UltimateTeam.Domain.Models;

namespace UltimateTeam.Application.Contracts.Repositories
{
    public interface IUrlRepository : IAsyncRepository<Url>
    {
        Task<IEnumerable<Url>> GetUrlsByCredentialId(Guid credentialId);
        Task RemoveUrlsByCredentialId(Guid credentialId);
        Task AddUrls(List<Url> urls);
    }
}