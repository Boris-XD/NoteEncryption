using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dev33.UltimateTeam.Application.Contracts.Repositories;
using Dev33.UltimateTeam.Domain.Models;
using Dev33.UltimateTeam.Infrastructure.Context;
using Dev33.UltimateTeam.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace UltimateTeam.Infrastructure.Repositories
{
    public class InformationRepository : BaseRepository<Information>, IInformationRepository
    {
        public InformationRepository(SafeInformationDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Information>> GetInformationsByContainerId(Guid containerId)
        {
            return await context.Set<Information>().Where(x => x.ContainerId == containerId).ToListAsync();
        }
    }
}