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
    public class PhoneRepository : BaseRepository<Phone>, IPhoneRepository
    {
        public PhoneRepository(SafeInformationDBContext context) : base(context)
        {
        }

        public async Task AddPhones(List<Phone> phones)
        {
            await context.Set<Phone>().AddRangeAsync(phones);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Phone>> GetPhonesByContactId(Guid contactId)
        {
            return await context.Set<Phone>().Where(x => x.ContactId == contactId).ToListAsync();
        }

        public async Task RemovePhonesByContactId(Guid contactId)
        {
            var phones = await GetPhonesByContactId(contactId);

            foreach (var phone in phones)
            {
                await DeleteAsync(phone);
            }

            await context.SaveChangesAsync();
        }
    }
}
