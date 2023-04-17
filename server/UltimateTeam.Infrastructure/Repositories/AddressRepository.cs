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
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(SafeInformationDBContext context) : base(context)
        {
        }

        public async Task AddAddresses(List<Address> addresses)
        {
            await context.Set<Address>().AddRangeAsync(addresses);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Address>> GetAddressesByContactId(Guid contactId)
        {
            return await context.Set<Address>().Where(x => x.ContactId == contactId).ToListAsync();
        }

        public async Task RemoveAddressesByContactId(Guid contactId)
        {
            var addresses = await GetAddressesByContactId(contactId);

            foreach (var address in addresses)
            {
                await DeleteAsync(address);
            }

            await context.SaveChangesAsync();
        }
    }
}
