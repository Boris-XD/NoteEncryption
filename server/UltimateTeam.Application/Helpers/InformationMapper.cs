using System;
using System.Collections.Generic;
using Dev33.UltimateTeam.Application.Dtos;
using Dev33.UltimateTeam.Domain.Enums;
using Dev33.UltimateTeam.Domain.Models;
using UltimateTeam.Application.Dtos;
using UltimateTeam.Application.Helpers;

namespace Dev33.UltimateTeam.Application.Helpers
{
    public class InformationMapper
    {
        public static Information Map(NoteRequestDto note)
        {
            var id = Guid.NewGuid();

            return new Information
            {
                Id = id,
                ContainerId = note.ContainerId,
                Description = note.Description,
                Favorite = note.Favorite,
                Name = note.Name,
                Type = (InformationType)Enum.Parse(typeof(InformationType), note.Type),
                EncryptionType = (EncryptorType)Enum.Parse(typeof(EncryptorType), note.EncryptionType),
                Tags = TagMapper.GetTags(note.Tags, id)
            };
        }

        public static Information Map(CreditCardRequestDto creditCard)
        {
            var id = Guid.NewGuid();

            return new Information
            {
                Id = id,
                ContainerId = creditCard.ContainerId,
                Description = creditCard.Description,
                Favorite = creditCard.Favorite,
                Name = creditCard.Name,
                Type = InformationType.CreditCard,
                EncryptionType = (EncryptorType)Enum.Parse(typeof(EncryptorType), creditCard.EncryptionType),
                Tags = TagMapper.GetTags(creditCard.Tags, id)
            };
        }

        public static Information Map(KeyRequestDto key)
        {
            var id = Guid.NewGuid();

            return new Information
            {
                Id = id,
                ContainerId = key.ContainerId,
                Description = key.Description,
                Favorite = key.Favorite,
                Name = key.Name,
                Type = (InformationType)Enum.Parse(typeof(InformationType), key.Type),
                EncryptionType = (EncryptorType)Enum.Parse(typeof(EncryptorType), key.EncryptionType),
                Tags = TagMapper.GetTags(key.Tags, id)
            };
        }

        public static List<InformationResponseDto> Map(IEnumerable<Information> informations)
        {
            var informationResponseDtos = new List<InformationResponseDto>();

            foreach (var information in informations)
            {
                var informationResponseDto = new InformationResponseDto
                {
                    Id = information.Id,
                    Favorite = information.Favorite,
                    Name = information.Name,
                    InformationType = information.Type.ToString()
                };

                informationResponseDtos.Add(informationResponseDto);
            }

            return informationResponseDtos;
        }

        public static Information Map(ContactRequestDto contact)
        {
            var id = Guid.NewGuid();

            return new Information
            {
                Id = id,
                ContainerId = contact.ContainerId,
                Description = contact.Description,
                Favorite = contact.Favorite,
                Name = contact.Name,
                Type = (InformationType)Enum.Parse(typeof(InformationType), contact.Type),
                EncryptionType = (EncryptorType)Enum.Parse(typeof(EncryptorType), contact.EncryptionType),
                Tags = TagMapper.GetTags(contact.Tags, id)
            };
        }

        public static Information Map(CredentialRequestDto credential)
        {
            var id = Guid.NewGuid();

            return new Information
            {
                Id = id,
                ContainerId = credential.ContainerId,
                Description = credential.Description,
                Favorite = credential.Favorite,
                Name = credential.Name,
                Type = (InformationType)Enum.Parse(typeof(InformationType), credential.Type),
                EncryptionType = (EncryptorType)Enum.Parse(typeof(EncryptorType), credential.EncryptionType),
                Tags = TagMapper.GetTags(credential.Tags, id)
            };
        }

        public static Information Map(Guid id, NoteRequestDto note)
        {
            return new Information
            {
                Id = id,
                ContainerId = note.ContainerId,
                Description = note.Description,
                Favorite = note.Favorite,
                Name = note.Name,
                Type = (InformationType)Enum.Parse(typeof(InformationType), note.Type),
                EncryptionType = (EncryptorType)Enum.Parse(typeof(EncryptorType), note.EncryptionType),
                Tags = TagMapper.GetTags(note.Tags, id)
            };
        }

        public static Information Map(Guid id, KeyRequestDto key)
        {
            return new Information
            {
                Id = id,
                ContainerId = key.ContainerId,
                Description = key.Description,
                Favorite = key.Favorite,
                Name = key.Name,
                Type = (InformationType)Enum.Parse(typeof(InformationType), key.Type),
                EncryptionType = (EncryptorType)Enum.Parse(typeof(EncryptorType), key.EncryptionType),
                Tags = TagMapper.GetTags(key.Tags, id)
            };
        }

        public static Information Map(Guid id, ContactRequestDto contact)
        {
            return new Information
            {
                Id = id,
                ContainerId = contact.ContainerId,
                Description = contact.Description,
                Favorite = contact.Favorite,
                Name = contact.Name,
                Type = (InformationType)Enum.Parse(typeof(InformationType), contact.Type),
                EncryptionType = (EncryptorType)Enum.Parse(typeof(EncryptorType), contact.EncryptionType),
                Tags = TagMapper.GetTags(contact.Tags, id)
            };
        }

        public static Information Map(Guid id, CreditCardRequestDto creditCard)
        {
            return new Information
            {
                Id = id,
                ContainerId = creditCard.ContainerId,
                Description = creditCard.Description,
                Favorite = creditCard.Favorite,
                Name = creditCard.Name,
                Type = (InformationType)Enum.Parse(typeof(InformationType), creditCard.Type),
                EncryptionType = (EncryptorType)Enum.Parse(typeof(EncryptorType), creditCard.EncryptionType),
                Tags = TagMapper.GetTags(creditCard.Tags, id)
            };
        }

        public static Information Map(Guid id, CredentialRequestDto credential)
        {
            return new Information
            {
                Id = id,
                ContainerId = credential.ContainerId,
                Description = credential.Description,
                Favorite = credential.Favorite,
                Name = credential.Name,
                Type = (InformationType)Enum.Parse(typeof(InformationType), credential.Type),
                EncryptionType = (EncryptorType)Enum.Parse(typeof(EncryptorType), credential.EncryptionType),
                Tags = TagMapper.GetTags(credential.Tags, id)
            };
        }
    }
}