using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dev33.UltimateTeam.Domain.Models;

namespace Dev33.UltimateTeam.Application.Contracts.Services
{
    public interface IAuthenticateService
    {
        Task<User> AuthenticateAsync(string email, string userName, string password);
        Task<User> RegisterAsync(User request);
    }
}
