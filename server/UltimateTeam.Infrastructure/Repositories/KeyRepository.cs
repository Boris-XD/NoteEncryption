using Dev33.UltimateTeam.Application.Contracts.Repositories;
using Dev33.UltimateTeam.Domain.Models;
using Dev33.UltimateTeam.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev33.UltimateTeam.Infrastructure.Repositories
{
    public class KeyRepository : BaseRepository<Key>, IKeyRepository
    {
        public KeyRepository(SafeInformationDBContext context) : base(context)
        {
        }
    }
}
