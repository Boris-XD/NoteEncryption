using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dev33.UltimateTeam.Domain.Models;
using Dev33.UltimateTeam.Application.Contracts.Repositories;
using Dev33.UltimateTeam.Infrastructure.Context;

namespace Dev33.UltimateTeam.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SafeInformationDBContext context) : base(context)
        {
        }
        public async Task<User> GetByEmailAsync(string email)
        {
            return await context.Set<User>().FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await context.Set<User>().FirstOrDefaultAsync(x => x.UserName == userName);
        }
    }
}