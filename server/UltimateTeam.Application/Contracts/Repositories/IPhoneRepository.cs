using Dev33.UltimateTeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev33.UltimateTeam.Application.Contracts.Repositories
{
    public interface IPhoneRepository : IAsyncRepository<Phone>
    {
        Task<IEnumerable<Phone>> GetPhonesByContactId(Guid contactId);
        Task RemovePhonesByContactId(Guid contactId);
        Task AddPhones(List<Phone> phones);
    }
}
