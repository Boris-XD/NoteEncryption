using System;
using Dev33.UltimateTeam.Application.Dtos;
using Dev33.UltimateTeam.Domain.Models;

namespace UltimateTeam.Application.Helpers
{
    public static class KeyMapper
    {
        public static Key Map(KeyRequestDto key, Guid id)
        {
            return new Key
            {
                InformationsId = id,
                Serial = key.Serial
            };
        }

        public static KeyResponseDto Map(Key key, Information information)
        {
            return new KeyResponseDto
            {
                Name = information.Name,
                Description = information.Description,
                Serial = key.Serial,
                Favorite = information.Favorite,
                EncryptionType = information.EncryptionType.ToString(),
                Type = information.Type.ToString(),
                Tags = TagMapper.Map(information.Tags)
            };
        }
    }
}