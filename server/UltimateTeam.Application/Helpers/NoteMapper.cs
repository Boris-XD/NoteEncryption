using Dev33.UltimateTeam.Domain.Models;
using System;
using System.Collections.Generic;
using UltimateTeam.Application.Dtos;

namespace UltimateTeam.Application.Helpers
{
    public static class NoteMapper
    {
        public static Note Map(NoteRequestDto note, Guid id)
        {
            return new Note
            {
                InformationsId = id,
                Text = note.Text,
            };
        }

        public static NoteResponseDto Map(Note note, Information information)
        {
            return new NoteResponseDto
            {
                Name = information.Name,
                Text = note.Text,
                Description = information.Description,
                Type = information.Type.ToString(),
                Favorite = information.Favorite,
                EncryptionType = information.EncryptionType.ToString(),
                Tags = TagMapper.Map(information.Tags)
            };
        }
    }
}