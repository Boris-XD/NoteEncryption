using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateTeam.Application.Dtos;

namespace Dev33.UltimateTeam.Application.Contracts.Services
{
    public interface INoteService
    {
        Task<NoteResponseDto> GetNoteById(Guid id);
        Task<NoteResponseDto> CreateNote(NoteRequestDto note);
        Task<NoteResponseDto> UpdateNote(NoteRequestDto note, Guid noteId);
        Task<NoteResponseDto> DeleteNote(Guid id);
    }
}
