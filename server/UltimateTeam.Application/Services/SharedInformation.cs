using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dev33.UltimateTeam.Application.Contracts.Repositories;
using Dev33.UltimateTeam.Application.Contracts.Services;
using Dev33.UltimateTeam.Application.Dtos;
using Dev33.UltimateTeam.Application.Helpers;

namespace UltimateTeam.Application.Services
{
    public class SharedInformation : ISharedInformation
    {
        private readonly IUnitOfWork unitOfWork;

        public SharedInformation(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<InformationsSharedResponseDto> GetInformationsShared(Guid userId)
        {
            var informationsShared = await unitOfWork.shareInformationRepository.GetByUserId(userId);
            var informationResponses = new InformationsSharedResponseDto();
            var listInfos = new List<InformationSharedResponseDto>();

            foreach (var informationShared in informationsShared)
            {
                var information = await unitOfWork.InformationRepository.GetByIdAsync(informationShared.InformationId);
                var containerFromInformation = await unitOfWork.ContainerRepository.GetByIdAsync(information.ContainerId);
                var owner = await unitOfWork.UserRepository.GetByIdAsync(containerFromInformation.UserId);
                var informationDto = SharedInformationMapper.Map(informationShared, owner, information);
                listInfos.Add(informationDto);
            }

            informationResponses.Informations = listInfos;

            return informationResponses;
        }


        public async Task<InformationSharedResponseDto> ShareInformation(Guid informationId, GuessDto guess)
        {
            var information = await unitOfWork.InformationRepository.GetByIdAsync(informationId);
            var guessExisted = await unitOfWork.UserRepository.GetByEmailAsync(guess.Email)
                                ?? await unitOfWork.UserRepository.GetByUserNameAsync(guess.Username);

            if (guessExisted == null || information == null)
            {
                throw new Exception("Guess or email not found");
            }

            var shareInformation = SharedInformationMapper.Map(information.Id, guessExisted.Id);
            var informationShared = await unitOfWork.shareInformationRepository.AddAsync(shareInformation);
            var containerFromInformation = await unitOfWork.ContainerRepository.GetByIdAsync(information.ContainerId);
            var owner = await unitOfWork.UserRepository.GetByIdAsync(containerFromInformation.UserId);

            return SharedInformationMapper.Map(informationShared, guessExisted, information);
        }
    }
}