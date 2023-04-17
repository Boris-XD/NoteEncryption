using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dev33.UltimateTeam.Domain.Models;
using Dev33.UltimateTeam.Infrastructure.Context;
using Dev33.UltimateTeam.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using UltimateTeam.Application.Contracts.Repositories;

namespace UltimateTeam.Infrastructure.Repositories
{
    public class UrlRepository : BaseRepository<Url>, IUrlRepository
    {
        public UrlRepository(SafeInformationDBContext context) : base(context)
        {
        }

        public async Task AddUrls(List<Url> urls)
        {
            await context.Set<Url>().AddRangeAsync(urls);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Url>> GetUrlsByCredentialId(Guid credentialId)
        {
            return await context.Set<Url>().Where(x => x.CredentialId == credentialId).ToListAsync();
        }

        public async Task RemoveUrlsByCredentialId(Guid credentialId)
        {
            var urls = await GetUrlsByCredentialId(credentialId);

            foreach (var url in urls)
            {
                await DeleteAsync(url);
            }

            await context.SaveChangesAsync();
        }
    }
}