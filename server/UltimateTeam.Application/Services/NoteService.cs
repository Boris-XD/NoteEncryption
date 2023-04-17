using Dev33.UltimateTeam.Application.Contracts.Repositories;
using Dev33.UltimateTeam.Application.Contracts.Services;
using Dev33.UltimateTeam.Application.Encyptors;
using Dev33.UltimateTeam.Application.Helpers;
using Dev33.UltimateTeam.Domain;
using Dev33.UltimateTeam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UltimateTeam.Application.Dtos;
using UltimateTeam.Application.Helpers;
using UltimateTeam.Application.Helpers.Factories;

namespace Dev33.UltimateTeam.Application.Services
{
    public class NoteService : INoteService
    {
        private readonly IUnitOfWork unitOfWork;
        private IEncryptor encryptor;

        public NoteService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<NoteResponseDto> CreateNote(NoteRequestDto note)
        {
            var containerExisted = await unitOfWork.ContainerRepository.GetByIdAsync(note.ContainerId);

            if (containerExisted == null)
            {
                throw new Exception("Not found container");
            }

            encryptor = FactoryEncryptor.Create(note.EncryptionType);
            var informationMapped = InformationMapper.Map(note);
            var noteMapped = NoteMapper.Map(note, informationMapped.Id);
            var noteEncrypted = HandleEncryption.HandleEncryptData(noteMapped, encryptor, true);
            var inforamationCreated = await unitOfWork.InformationRepository.AddAsync(informationMapped);
            var noteCreated = await unitOfWork.NoteRepository.AddAsync((Note)noteEncrypted);
            var tags = await unitOfWork.TagRepository.GetTagsAsync(inforamationCreated.Id);
            inforamationCreated.Tags = (List<Tag>)tags;

            return NoteMapper.Map(noteCreated, inforamationCreated);
        }

        public async Task<NoteResponseDto> DeleteNote(Guid id)
        {
            var note = await unitOfWork.NoteRepository.GetByIdAsync(id);
            var information = await unitOfWork.InformationRepository.GetByIdAsync(note.InformationsId);
            ValidateExistence(note, information);
            var tags = await unitOfWork.TagRepository.GetTagsAsync(information.Id);
            information.Tags = (List<Tag>)tags;
            await unitOfWork.NoteRepository.DeleteAsync(note);
            await unitOfWork.InformationRepository.DeleteAsync(information);

            return NoteMapper.Map(note, information);
        }

        public async Task<NoteResponseDto> GetNoteById(Guid id)
        {
            var information = await unitOfWork.InformationRepository.GetByIdAsync(id);
            var note = await unitOfWork.NoteRepository.GetByIdAsync(id);
            ValidateExistence(note, information);
            var tags = await unitOfWork.TagRepository.GetTagsAsync(information.Id);
            information.Tags = (List<Tag>)tags;
            encryptor = FactoryEncryptor.Create(information.EncryptionType.ToString());
            var noteDecrypted = HandleEncryption.HandleEncryptData(note, encryptor, false);

            return NoteMapper.Map((Note)noteDecrypted, information);
        }

        public async Task<NoteResponseDto> UpdateNote(NoteRequestDto note, Guid noteId)
        {
            var informationExisted = await unitOfWork.InformationRepository.GetByIdAsync(noteId);
            var noteExisted = await unitOfWork.NoteRepository.GetByIdAsync(noteId);
            ValidateExistence(noteExisted, informationExisted);
            var informationMapped = InformationMapper.Map(noteId, note);
            var noteMapped = NoteMapper.Map(note, informationMapped.Id);
            await unitOfWork.TagRepository.RemoveTagsAsync(informationExisted.Id);
            await unitOfWork.TagRepository.AddTagsAsync((List<Tag>)informationMapped.Tags);
            encryptor = FactoryEncryptor.Create(informationMapped.EncryptionType.ToString());
            var noteEncrypted = HandleEncryption.HandleEncryptData(noteMapped, encryptor, true);
            await unitOfWork.InformationRepository.UpdateAsync(informationMapped);
            await unitOfWork.NoteRepository.UpdateAsync((Note)noteEncrypted);

            return NoteMapper.Map(noteMapped, informationMapped);
        }

        private void ValidateExistence(Note note, Information information)
        {
            if (note == null || information == null)
            {
                throw new ArgumentException("Note not found");
            }
        }
    }
}
