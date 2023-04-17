using Dev33.UltimateTeam.Application.Contracts.Repositories;
using Dev33.UltimateTeam.Domain.Models;
using Dev33.UltimateTeam.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev33.UltimateTeam.Infrastructure.Repositories
{
    public class ShareInformationRepository : BaseRepository<ShareInformation>, IShareInformationRepository
    {
        public ShareInformationRepository(SafeInformationDBContext context) : base(context)
        {
        }

        public async Task<ICollection<ShareInformation>> GetByUserId(Guid userId)
        {
            return await context.ShareInformations.Where(x => x.GuessId == userId).ToListAsync();
        }
    }
}
