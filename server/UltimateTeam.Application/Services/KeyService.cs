using Dev33.UltimateTeam.Application.Contracts.Repositories;
using Dev33.UltimateTeam.Application.Contracts.Services;
using Dev33.UltimateTeam.Application.Dtos;
using Dev33.UltimateTeam.Application.Encyptors;
using Dev33.UltimateTeam.Application.Helpers;
using Dev33.UltimateTeam.Domain;
using Dev33.UltimateTeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateTeam.Application.Helpers;
using UltimateTeam.Application.Helpers.Factories;

namespace Dev33.UltimateTeam.Application.Services
{
    public class KeyService : IKeyService
    {
        private readonly IUnitOfWork unitOfWork;
        private IEncryptor encryptor;

        public KeyService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<KeyResponseDto> CreateKey(KeyRequestDto key)
        {
            var containerExisted = await unitOfWork.ContainerRepository.GetByIdAsync(key.ContainerId);

            if (containerExisted == null)
            {
                throw new Exception("Container not found");
            }

            encryptor = FactoryEncryptor.Create(key.EncryptionType);
            var informationMapped = InformationMapper.Map(key);
            var keyMapped = KeyMapper.Map(key, informationMapped.Id);
            var keyEncrypted = HandleEncryption.HandleEncryptData(keyMapped, encryptor, encrypt: true);
            var informationCreated = await unitOfWork.InformationRepository.AddAsync(informationMapped);
            var keyCreated = await unitOfWork.KeyRepository.AddAsync((Key)keyEncrypted);
            var tags = await unitOfWork.TagRepository.GetTagsAsync(informationCreated.Id);
            informationCreated.Tags = (List<Tag>)tags;

            return KeyMapper.Map(keyCreated, informationCreated);
        }

        public async Task<KeyResponseDto> DeleteKey(Guid id)
        {
            var key = await unitOfWork.KeyRepository.GetByIdAsync(id);
            var information = await unitOfWork.InformationRepository.GetByIdAsync(key.InformationsId);
            var tags = await unitOfWork.TagRepository.GetTagsAsync(information.Id);
            information.Tags = (List<Tag>)tags;
            await unitOfWork.KeyRepository.DeleteAsync(key);
            await unitOfWork.InformationRepository.DeleteAsync(information);

            return KeyMapper.Map(key, information);
        }

        public async Task<KeyResponseDto> GetKeyById(Guid id)
        {
            var information = await unitOfWork.InformationRepository.GetByIdAsync(id);
            var tags = await unitOfWork.TagRepository.GetTagsAsync(information.Id);
            information.Tags = (List<Tag>)tags;
            var key = await unitOfWork.KeyRepository.GetByIdAsync(information.Id);
            ValidateExistence(information, key);
            encryptor = FactoryEncryptor.Create(information.EncryptionType.ToString());
            var keyDecrypted = HandleEncryption.HandleEncryptData(key, encryptor, encrypt: false);

            return KeyMapper.Map((Key)keyDecrypted, information);
        }

        public async Task<KeyResponseDto> UpdateKey(KeyRequestDto key, Guid keyId)
        {
            var informationExisted = await unitOfWork.InformationRepository.GetByIdAsync(keyId);
            var keyExisted = await unitOfWork.KeyRepository.GetByIdAsync(keyId);
            ValidateExistence(informationExisted, keyExisted);
            var informationMapped = InformationMapper.Map(informationExisted.Id, key);
            var keyMapped = KeyMapper.Map(key, informationMapped.Id);
            await unitOfWork.TagRepository.RemoveTagsAsync(informationExisted.Id);
            await unitOfWork.InformationRepository.UpdateAsync(informationMapped);
            await unitOfWork.TagRepository.AddTagsAsync((List<Tag>)informationMapped.Tags);
            encryptor = FactoryEncryptor.Create(informationMapped.EncryptionType.ToString());
            var keyEncrypted = HandleEncryption.HandleEncryptData(keyMapped, encryptor, encrypt: true);
            await unitOfWork.InformationRepository.UpdateAsync(informationMapped);
            await unitOfWork.KeyRepository.UpdateAsync((Key)keyEncrypted);

            return KeyMapper.Map((Key)keyEncrypted, informationMapped);
        }

        private void ValidateExistence(Information information, Key key)
        {
            if (information == null || key == null)
            {
                throw new Exception("Key not found");
            }
        }
    }
}
