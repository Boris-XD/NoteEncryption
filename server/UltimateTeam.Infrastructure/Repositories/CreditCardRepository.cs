using Dev33.UltimateTeam.Domain.Models;
using Dev33.UltimateTeam.Infrastructure.Context;
using Dev33.UltimateTeam.Infrastructure.Repositories;
using UltimateTeam.Application.Contracts.Repositories;

namespace UltimateTeam.Infrastructure.Repositories
{
    public class CreditCardRepository : BaseRepository<CreditCard>, ICreditCardRepository
    {
        public CreditCardRepository(SafeInformationDBContext context) : base(context)
        {
        }
    }
}