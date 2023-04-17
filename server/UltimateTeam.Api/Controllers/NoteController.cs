using System;
using System.Threading.Tasks;
using Dev33.UltimateTeam.Api.Services.LoggerService;
using Dev33.UltimateTeam.Application.Contracts.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltimateTeam.Application.Dtos;

namespace UltimateTeam.Api.Controllers
{
    [Route("api/users/{userId:guid}/containers/{containerId:guid}/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private INoteService noteService;
        private readonly ILoggerManager loggerManager;

        public NoteController(INoteService noteService, ILoggerManager loggerManager)
        {
            this.noteService = noteService;
            this.loggerManager = loggerManager;
        }

        [HttpGet("{noteId:guid}")]
        public async Task<ActionResult<NoteResponseDto>> GetById(Guid noteId)
        {
            try
            {
                var note = await noteService.GetNoteById(noteId);

                return Ok(note);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<NoteResponseDto>> Create(NoteRequestDto note)
        {
            try
            {
                var createdNote = await noteService.CreateNote(note);

                return Ok(createdNote);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{noteId:guid}")]
        public async Task<ActionResult<NoteResponseDto>> Update(Guid noteId, NoteRequestDto note)
        {
            try
            {
                var updatedNote = await noteService.UpdateNote(note, noteId);
                return Ok(updatedNote);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{noteId:guid}")]
        public async Task<ActionResult<NoteResponseDto>> Delete(Guid noteId)
        {
            try
            {
                var deletedNote = await noteService.DeleteNote(noteId);

                return Ok(deletedNote);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);

                return BadRequest(ex.Message);
            }
        }
    }
}