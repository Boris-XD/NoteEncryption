using Dev33.UltimateTeam.Application.Contracts.Repositories;
using Dev33.UltimateTeam.Application.Contracts.Services;
using Dev33.UltimateTeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev33.UltimateTeam.Application.Services
{
    public class ContainerService : IContainerService
    {
        private readonly IUnitOfWork unitOfWork;

        public ContainerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Container> CreateContainer(Container request)
        {
            var container = await unitOfWork.ContainerRepository.AddAsync(request);

            return container;
        }

        public async Task<Container> DeleteContainer(Guid containerId)
        {
            var container = await unitOfWork.ContainerRepository.GetByIdAsync(containerId);

            if (container == null)
            {
                throw new Exception("Container id not found");
            }

            await unitOfWork.ContainerRepository.DeleteAsync(container);

            return container;
        }

        public async Task<Container> GetContainerById(Guid containerId)
        {
            var container = await unitOfWork.ContainerRepository.GetByIdAsync(containerId);

            if (container == null)
            {
                throw new Exception("Container id not found");
            }

            var informations = await unitOfWork.InformationRepository.GetInformationsByContainerId(containerId);
            container.Information = (ICollection<Information>)informations;

            return container;
        }
        
        public async Task<IEnumerable<Container>> GetContainersByUserId(Guid request)
        {
            var user = await unitOfWork.UserRepository.GetByIdAsync(request);

            if (user == null)
            {
                throw new Exception("User id not found");
            }

            var containers = await unitOfWork.ContainerRepository.GetAllAsync();

            var response = containers.Where(x => x.UserId == request);

            return response;
        }

        public async Task<Container> UpdateContainer(Container container)
        {
            await unitOfWork.ContainerRepository.UpdateAsync(container);

            return container;
        }
    }
}
