using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dev33.UltimateTeam.Application.Contracts.Repositories;
using Dev33.UltimateTeam.Application.Dtos;
using Dev33.UltimateTeam.Application.Encyptors;
using Dev33.UltimateTeam.Application.Helpers;
using Dev33.UltimateTeam.Domain.Models;
using UltimateTeam.Application.Contracts.Services;
using UltimateTeam.Application.Helpers;
using UltimateTeam.Application.Helpers.Factories;

namespace UltimateTeam.Application.Services
{
    public class CredentialService : ICredentialService
    {
        private readonly IUnitOfWork unitOfWork;
        private IEncryptor encryptor;

        public CredentialService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<CredentialResponseDto> CreateCredential(CredentialRequestDto credential)
        {
            var containerExisted = await unitOfWork.ContainerRepository.GetByIdAsync(credential.ContainerId);

            if (containerExisted == null)
            {
                throw new Exception("Container not found");
            }

            encryptor = FactoryEncryptor.Create(credential.EncryptionType);
            var informationMapped = InformationMapper.Map(credential);
            var credentialMapped = CredentialMapper.Map(credential, informationMapped.Id);
            var credentialEncrypted = HandleEncryption.HandleEncryptData(credentialMapped, encryptor, encrypt: true);
            var informationCreated = await unitOfWork.InformationRepository.AddAsync(informationMapped);
            var credentialCreated = await unitOfWork.CredentialRepository.AddAsync((Credential)credentialEncrypted);
            var tags = await unitOfWork.TagRepository.GetTagsAsync(informationCreated.Id);
            informationCreated.Tags = (List<Tag>)tags;

            return CredentialMapper.Map(credentialCreated, informationCreated);
        }

        public async Task<CredentialResponseDto> DeleteCredential(Guid id)
        {
            var credential = await unitOfWork.CredentialRepository.GetByIdAsync(id);
            var information = await unitOfWork.InformationRepository.GetByIdAsync(id);
            ValidateExistence(credential, information);
            var tags = await unitOfWork.TagRepository.GetTagsAsync(id);
            information.Tags = (List<Tag>)tags;
            await unitOfWork.CredentialRepository.DeleteAsync(credential);
            await unitOfWork.InformationRepository.DeleteAsync(information);

            return CredentialMapper.Map(credential, information);
        }

        private void ValidateExistence(Credential credential, Information information)
        {
            if (credential == null || information == null)
            {
                throw new Exception("Credential not found");
            }
        }

        public async Task<CredentialResponseDto> GetCredentialById(Guid id)
        {
            var information = await unitOfWork.InformationRepository.GetByIdAsync(id);
            var credential = await unitOfWork.CredentialRepository.GetByIdAsync(id);
            ValidateExistence(credential, information);
            var tags = await unitOfWork.TagRepository.GetTagsAsync(id);
            var urls = await unitOfWork.UrlRepository.GetUrlsByCredentialId(id);
            information.Tags = (List<Tag>)tags;
            credential.Urls = (List<Url>)urls;
            encryptor = FactoryEncryptor.Create(information.EncryptionType.ToString());
            var credentialDecrypted = HandleEncryption.HandleEncryptData(credential, encryptor, encrypt: false);

            return CredentialMapper.Map((Credential)credentialDecrypted, information);
        }

        public async Task<CredentialResponseDto> UpdateCredential(CredentialRequestDto credential, Guid id)
        {
            var informationExisted = await unitOfWork.InformationRepository.GetByIdAsync(id);
            var credentialExisted = await unitOfWork.CredentialRepository.GetByIdAsync(id);
            ValidateExistence(credentialExisted, informationExisted);
            await unitOfWork.CredentialRepository.DeleteAsync(credentialExisted);
            var informationMapped = InformationMapper.Map(id, credential);
            var credentialMapped = CredentialMapper.Map(credential, id);
            await unitOfWork.TagRepository.RemoveTagsAsync(id);
            await unitOfWork.InformationRepository.UpdateAsync(informationMapped);
            await unitOfWork.TagRepository.AddTagsAsync((List<Tag>)informationMapped.Tags);
            encryptor = FactoryEncryptor.Create(credential.EncryptionType);
            var credentialEncrypted = HandleEncryption.HandleEncryptData(credentialMapped, encryptor, encrypt: true);
            await unitOfWork.CredentialRepository.AddAsync((Credential)credentialEncrypted);

            return CredentialMapper.Map((Credential)credentialEncrypted, informationMapped);
        }
    }
}