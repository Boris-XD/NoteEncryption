using System;
using System.Collections.Generic;

namespace UltimateTeam.Application.Dtos
{
    public class NoteResponseDto
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string EncryptionType { get; set; }
        public bool Favorite { get; set; }
        public List<string> Tags { get; set; }
    }
}