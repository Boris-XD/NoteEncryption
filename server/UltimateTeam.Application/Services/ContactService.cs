using Dev33.UltimateTeam.Application.Contracts.Repositories;
using Dev33.UltimateTeam.Application.Contracts.Services;
using Dev33.UltimateTeam.Application.Dtos;
using Dev33.UltimateTeam.Application.Encyptors;
using Dev33.UltimateTeam.Application.Helpers;
using Dev33.UltimateTeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateTeam.Application.Helpers.Factories;

namespace Dev33.UltimateTeam.Application.Services
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork unitOfWork;
        private IEncryptor encryptor;

        public ContactService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<ContactResponseDto> CreateContact(ContactRequestDto contact)
        {
            var containerExisted = await unitOfWork.ContainerRepository.GetByIdAsync(contact.ContainerId);

            if (containerExisted == null)
            {
                throw new Exception("Container not found");
            }

            encryptor = FactoryEncryptor.Create(contact.EncryptionType);
            var informationMapped = InformationMapper.Map(contact);
            var contactMapped = ContactMapper.Map(contact, informationMapped.Id);
            var contactEncrypted = HandleEncryption.HandleEncryptData(contactMapped, encryptor, encrypt: true);
            var informationCreated = await unitOfWork.InformationRepository.AddAsync(informationMapped);
            var contactCreated = await unitOfWork.ContactRepository.AddAsync((Contact)contactEncrypted);
            var tags = await unitOfWork.TagRepository.GetTagsAsync(informationCreated.Id);
            informationCreated.Tags = (List<Tag>)tags;

            return ContactMapper.Map(contactCreated, informationCreated);
        }

        public async Task<ContactResponseDto> DeleteContact(Guid id)
        {

            var contact = await unitOfWork.ContactRepository.GetByIdAsync(id);
            var information = await unitOfWork.InformationRepository.GetByIdAsync(id);
            var tags = await unitOfWork.TagRepository.GetTagsAsync(id);
            information.Tags = (List<Tag>)tags;
            await unitOfWork.ContactRepository.DeleteAsync(contact);
            await unitOfWork.InformationRepository.DeleteAsync(information);

            return ContactMapper.Map(contact, information);
        }

        public async Task<ContactResponseDto> GetContactById(Guid id)
        {
            var information = await unitOfWork.InformationRepository.GetByIdAsync(id);
            var contact = await unitOfWork.ContactRepository.GetByIdAsync(id);
            ValidateContact(contact, information);
            var tags = await unitOfWork.TagRepository.GetTagsAsync(id);
            var emails = await unitOfWork.EmailRepository.GetEmailsByContactId(id);
            var phones = await unitOfWork.PhoneRepository.GetPhonesByContactId(id);
            var addresses = await unitOfWork.AddressRepository.GetAddressesByContactId(id);
            information.Tags = (List<Tag>)tags;
            contact.Emails = (List<Email>)emails;
            contact.Phones = (List<Phone>)phones;
            contact.Addresses = (List<Address>)addresses;
            encryptor = FactoryEncryptor.Create(information.EncryptionType.ToString());
            var contactDecrypted = HandleEncryption.HandleEncryptData(contact, encryptor, encrypt: false);

            return ContactMapper.Map((Contact)contactDecrypted, information);
        }

        public async Task<ContactResponseDto> UpdateContact(ContactRequestDto contact, Guid id)
        {
            var informationExisted = await unitOfWork.InformationRepository.GetByIdAsync(id);
            var contactExisted = await unitOfWork.ContactRepository.GetByIdAsync(id);
            ValidateContact(contactExisted, informationExisted);
            await unitOfWork.ContactRepository.DeleteAsync(contactExisted);
            var informationMapped = InformationMapper.Map(id, contact);
            var contactMapped = ContactMapper.Map(contact, informationMapped.Id);
            await unitOfWork.TagRepository.RemoveTagsAsync(informationExisted.Id);
            await unitOfWork.InformationRepository.UpdateAsync(informationMapped);
            await unitOfWork.TagRepository.AddTagsAsync((List<Tag>)informationMapped.Tags);
            encryptor = FactoryEncryptor.Create(informationMapped.EncryptionType.ToString());
            var contactEncrypted = HandleEncryption.HandleEncryptData(contactMapped, encryptor, encrypt: true);
            await unitOfWork.ContactRepository.AddAsync((Contact)contactEncrypted);

            return ContactMapper.Map((Contact)contactEncrypted, informationMapped);
        }

        private void ValidateContact(Contact contact, Information information)
        {
            if (contact == null || information == null)
            {
                throw new Exception("Contact not found");
            }
        }
    }
}
