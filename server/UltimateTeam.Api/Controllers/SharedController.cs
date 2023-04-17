using System;
using System.Threading.Tasks;
using Dev33.UltimateTeam.Api.Services.LoggerService;
using Dev33.UltimateTeam.Application.Contracts.Services;
using Dev33.UltimateTeam.Application.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltimateTeam.Application.Dtos;

namespace UltimateTeam.Api.Controllers
{
    [Route("api/users/{userId:guid}/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class SharedController : ControllerBase
    {
        private readonly ISharedInformation sharedService;
        private readonly ILoggerManager loggerManager;

        public SharedController(ISharedInformation sharedService, ILoggerManager loggerManager)
        {
            this.sharedService = sharedService;
            this.loggerManager = loggerManager;
        }

        [HttpPost("items/{itemId:guid}")]
        public async Task<ActionResult<InformationResponseDto>> Create(Guid itemId, [FromBody] GuessDto guess)
        {
            try
            {
                var response = await sharedService.ShareInformation(itemId, guess);

                return Ok(response);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<InformationsSharedResponseDto>> Get(Guid userId)
        {
            try
            {
                var response = await sharedService.GetInformationsShared(userId);

                return Ok(response);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);

                return BadRequest(ex.Message);
            }
        }
    }
}