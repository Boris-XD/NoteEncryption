using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Dev33.UltimateTeam.Api.Services.LoggerService;
using Dev33.UltimateTeam.Application.Contracts.Services;
using Dev33.UltimateTeam.Application.Helpers;
using Dev33.UltimateTeam.Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltimateTeam.Application.Dtos;

namespace UltimateTeam.Api.Controllers
{
    [Route("api/users/{userId:guid}/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class InformationController : ControllerBase
    {
        private readonly ISearchService searchService;
        private readonly ILoggerManager logger;
        private readonly IMapper mapper;

        public InformationController(ISearchService searchService, ILoggerManager logger, IMapper mapper)
        {
            this.searchService = searchService;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet("searchTerm")]
        public async Task<IEnumerable<InformationResponseDto>> Search(Guid userId, [FromQuery] string searchTerm)
        {
            try
            {
                var informations = await searchService.Search(userId, searchTerm);
                var response = InformationMapper.Map(informations);

                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex);
                return null;
            }
        }
    }
}
