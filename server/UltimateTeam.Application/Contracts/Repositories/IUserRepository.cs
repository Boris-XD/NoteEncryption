using Dev33.UltimateTeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev33.UltimateTeam.Application.Contracts.Repositories
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByUserNameAsync(string userName);
    }
}
