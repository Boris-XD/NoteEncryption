using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dev33.UltimateTeam.Application.Contracts.Repositories;
using Dev33.UltimateTeam.Application.Dtos;
using Dev33.UltimateTeam.Application.Encyptors;
using Dev33.UltimateTeam.Application.Helpers;
using Dev33.UltimateTeam.Domain;
using Dev33.UltimateTeam.Domain.Models;
using UltimateTeam.Application.Contracts.Services;
using UltimateTeam.Application.Dtos;
using UltimateTeam.Application.Helpers;
using UltimateTeam.Application.Helpers.Factories;

namespace UltimateTeam.Application.Services
{
    public class CreditCardService : ICreditCardService
    {
        private readonly IUnitOfWork unitOfWork;
        private IEncryptor encryptor;

        public CreditCardService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<CreditCardResponseDto> CreateCard(CreditCardRequestDto creditCard)
        {
            var containerExisted = await unitOfWork.ContainerRepository.GetByIdAsync(creditCard.ContainerId);

            if (containerExisted == null)
            {
                throw new Exception("Container not found");
            }

            encryptor = FactoryEncryptor.Create(creditCard.EncryptionType);
            var informationMapped = InformationMapper.Map(creditCard);
            var creditCardMapped = CreditCardMapper.Map(creditCard, informationMapped.Id);
            var creditCardEncrypted = HandleEncryption.HandleEncryptData(creditCardMapped, encryptor, encrypt: true);
            var informationCreated = await unitOfWork.InformationRepository.AddAsync(informationMapped);
            var creditCardCreated = await unitOfWork.CreditCardRepository.AddAsync((CreditCard)creditCardEncrypted);
            var tags = await unitOfWork.TagRepository.GetTagsAsync(informationCreated.Id);
            informationCreated.Tags = (List<Tag>)tags;

            return CreditCardMapper.Map(creditCardCreated, informationCreated);
        }

        public async Task<CreditCardResponseDto> DeleteCard(Guid id)
        {
            var creditCard = await unitOfWork.CreditCardRepository.GetByIdAsync(id);
            var information = await unitOfWork.InformationRepository.GetByIdAsync(id);
            ValidateExistingCard(creditCard, information);
            var tags = await unitOfWork.TagRepository.GetTagsAsync(information.Id);
            information.Tags = (List<Tag>)tags;
            await unitOfWork.CreditCardRepository.DeleteAsync(creditCard);
            await unitOfWork.InformationRepository.DeleteAsync(information);

            return CreditCardMapper.Map(creditCard, information);
        }

        public async Task<CreditCardResponseDto> GetCreditCardById(Guid id)
        {
            var information = await unitOfWork.InformationRepository.GetByIdAsync(id);
            var creditCard = await unitOfWork.CreditCardRepository.GetByIdAsync(id);
            ValidateExistingCard(creditCard, information);
            var tags = await unitOfWork.TagRepository.GetTagsAsync(id);
            information.Tags = (List<Tag>)tags;
            encryptor = FactoryEncryptor.Create(information.EncryptionType.ToString());
            var creditCardDecrypted = HandleEncryption.HandleEncryptData(creditCard, encryptor, encrypt: false);

            return CreditCardMapper.Map((CreditCard)creditCardDecrypted, information);
        }

        public async Task<CreditCardResponseDto> UpdateCard(CreditCardRequestDto creditCard, Guid id)
        {
            var informationExisted = await unitOfWork.InformationRepository.GetByIdAsync(id);
            var creditCardExisted = await unitOfWork.CreditCardRepository.GetByIdAsync(id);
            ValidateExistingCard(creditCardExisted, informationExisted);
            var informationMapped = InformationMapper.Map(id, creditCard);
            var creditCardMapped = CreditCardMapper.Map(creditCard, id);
            await unitOfWork.TagRepository.RemoveTagsAsync(id);
            await unitOfWork.InformationRepository.UpdateAsync(informationMapped);
            await unitOfWork.TagRepository.AddTagsAsync((List<Tag>)informationMapped.Tags);
            encryptor = FactoryEncryptor.Create(creditCard.EncryptionType);
            var creditCardEncrypted = HandleEncryption.HandleEncryptData(creditCardMapped, encryptor, encrypt: true);
            await unitOfWork.InformationRepository.UpdateAsync(informationMapped);
            await unitOfWork.CreditCardRepository.UpdateAsync((CreditCard)creditCardEncrypted);

            return CreditCardMapper.Map((CreditCard)creditCardEncrypted, informationMapped);
        }

        private void ValidateExistingCard(CreditCard creditCard, Information information)
        {
            if (creditCard == null || information == null)
            {
                throw new Exception("Card not found");
            }
        }
    }
}