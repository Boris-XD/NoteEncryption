using System;
using System.Collections.Generic;
using Dev33.UltimateTeam.Application.Dtos;
using Dev33.UltimateTeam.Domain.Models;

namespace UltimateTeam.Application.Helpers
{
    public static class CredentialMapper
    {
        public static Credential Map(CredentialRequestDto credential, Guid id)
        {
            return new Credential
            {
                InformationsId = id,
                UserName = credential.Username,
                Password = credential.Password,
                Urls = UrlMapper.Map(credential.Urls, id)
            };
        }

        public static CredentialResponseDto Map(Credential credential, Information information)
        {
            return new CredentialResponseDto
            {
                Id = credential.InformationsId,
                Username = credential.UserName,
                Password = credential.Password,
                Urls = UrlMapper.Map((List<Url>)credential.Urls),
                Name = information.Name,
                Description = information.Description,
                Favorite = information.Favorite,
                ContainerId = information.ContainerId,
                Type = information.Type.ToString(),
                EncryptionType = information.EncryptionType.ToString(),
                Tags = TagMapper.Map(information.Tags)
            };
        }
    }
}