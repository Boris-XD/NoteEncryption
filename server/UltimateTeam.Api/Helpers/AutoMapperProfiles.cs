using AutoMapper;
using Dev33.UltimateTeam.Application.Dtos;
using Dev33.UltimateTeam.Domain.Models;
using UltimateTeam.Application.Dtos;

namespace UltimateTeam.Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserResponseDto>();
            CreateMap<Container, ContainerResponseDto>();
            CreateMap<ContainerRequestDto, Container>();
            CreateMap<Container, ContainerSpecifyResponseDto>();
            CreateMap<Information, InformationResponseDto>();
            CreateMap<NoteRequestDto, Information>();
            CreateMap<NoteRequestDto, Note>();
        }
    }
}