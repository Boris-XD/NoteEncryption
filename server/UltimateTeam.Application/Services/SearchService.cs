using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dev33.UltimateTeam.Application.Contracts.Repositories;
using Dev33.UltimateTeam.Application.Contracts.Services;
using Dev33.UltimateTeam.Application.Encyptors;
using Dev33.UltimateTeam.Application.Helpers;
using Dev33.UltimateTeam.Domain.Enums;
using Dev33.UltimateTeam.Domain.Models;
using UltimateTeam.Application.Helpers.Factories;

namespace UltimateTeam.Application.Services
{
    public class SearchService : ISearchService
    {
        private IEncryptor encryptor;
        private readonly IUnitOfWork unitOfWork;

        public SearchService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Information>> Search(Guid userId, string searchTerm)
        {
            var allContainers = await unitOfWork.ContainerRepository.GetAllAsync();
            var containerByUser = allContainers.Where(x => x.UserId == userId);
            var response = new List<Information>();

            foreach (var container in containerByUser)
            {
                var items = await unitOfWork.InformationRepository.GetAllAsync();
                var itemsByContainer = items.Where(x => x.ContainerId == container.Id);

                foreach (var item in itemsByContainer)
                {
                    var information = await BuildInformation(item.Type, item.Id);
                    var tags = await unitOfWork.TagRepository.GetTagsAsync(item.Id);
                    item.Tags = (ICollection<Tag>)tags;
                    AddInformation(item, information);

                    if (HandleSearch.HandleSearchBasic(item, searchTerm))
                    {
                        response.Add(item);
                    }
                    else if (searchTerm.Contains(":"))
                    {
                        var field = searchTerm.Split(':').First();
                        var value = searchTerm.Split(':').Last();
                        encryptor = FactoryEncryptor.Create(item.EncryptionType.ToString());
                        var informationAux = await BuildInformation(item.Type, item.Id);
                        var decryptedValue = HandleEncryption.HandleEncryptData(informationAux, encryptor, encrypt: false);
                        AddInformation(item, decryptedValue);

                        if (HandleSearch.HandleSearchAdvanced(decryptedValue, field, value))
                        {
                            response.Add(item);
                        }
                    }
                }
            }

            return response;
        }

        private void AddInformation(Information item, object information)
        {
            switch (item.Type)
            {
                case InformationType.Note:
                    item.Note = (Note)information;
                    break;
                case InformationType.Credential:
                    item.Credential = (Credential)information;
                    break;
                case InformationType.CreditCard:
                    item.CreditCard = (CreditCard)information;
                    break;
                case InformationType.Contact:
                    item.Contact = (Contact)information;
                    break;
                case InformationType.Key:
                    item.Key = (Key)information;
                    break;
                default:
                    throw new NotImplementedException($"{item.Type} is not implemented");
            }
        }

        private async Task<object> BuildInformation(InformationType type, Guid id)
        {
            switch (type)
            {
                case InformationType.Note:
                    return await unitOfWork.NoteRepository.GetByIdAsync(id);
                case InformationType.Key:
                    return await unitOfWork.KeyRepository.GetByIdAsync(id);
                case InformationType.Credential:
                    var credential = await unitOfWork.CredentialRepository.GetByIdAsync(id);
                    credential.Urls = (ICollection<Url>)await unitOfWork.UrlRepository.GetUrlsByCredentialId(credential.InformationsId);
                    return credential;
                    break;
                case InformationType.Contact:
                    var contact = await unitOfWork.ContactRepository.GetByIdAsync(id);
                    contact.Phones = (ICollection<Phone>)await unitOfWork.PhoneRepository.GetPhonesByContactId(contact.InformationsId);
                    contact.Emails = (ICollection<Email>)await unitOfWork.EmailRepository.GetEmailsByContactId(contact.InformationsId);
                    contact.Addresses = (ICollection<Address>)await unitOfWork.AddressRepository.GetAddressesByContactId(contact.InformationsId);
                    return contact;
                    break;
                case InformationType.CreditCard:
                    return await unitOfWork.CreditCardRepository.GetByIdAsync(id);
                default:
                    throw new NotImplementedException($"{type} is not implemented");
            }
        }
    }
}
