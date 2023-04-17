using Dev33.UltimateTeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev33.UltimateTeam.Application.Contracts.Services
{
    public interface IContainerService
    {
        Task<IEnumerable<Container>> GetContainersByUserId(Guid request);

        Task<Container> CreateContainer(Container request);
        Task<Container> DeleteContainer(Guid containerId);
        Task<Container> GetContainerById(Guid containerId);
        Task<Container> UpdateContainer(Container container);
    }
}
