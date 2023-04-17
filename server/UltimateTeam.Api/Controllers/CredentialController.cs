using System;
using System.Threading.Tasks;
using Dev33.UltimateTeam.Api.Services.LoggerService;
using Dev33.UltimateTeam.Application.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltimateTeam.Application.Contracts.Services;

namespace UltimateTeam.Api.Controllers
{
    [Route("api/users/{userId:guid}/containers/{containerId:guid}/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class CredentialController : ControllerBase
    {
        private readonly ICredentialService credentialService;
        private readonly ILoggerManager loggerManager;

        public CredentialController(ICredentialService credentialService, ILoggerManager loggerManager)
        {
            this.credentialService = credentialService;
            this.loggerManager = loggerManager;
        }

        [HttpGet("{credentialId:guid}")]
        public async Task<ActionResult<CredentialResponseDto>> GetById(Guid credentialId)
        {
            try
            {
                var response = await credentialService.GetCredentialById(credentialId);

                return Ok(response);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CredentialResponseDto>> Create(CredentialRequestDto contact)
        {
            try
            {
                var response = await credentialService.CreateCredential(contact);

                return Ok(response);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{credentialId:guid}")]
        public async Task<ActionResult<CredentialResponseDto>> Update(Guid credentialId, CredentialRequestDto credentialCard)
        {
            try
            {
                var response = await credentialService.UpdateCredential(credentialCard, credentialId);

                return Ok(response);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{credentialId:guid}")]
        public async Task<ActionResult<CredentialResponseDto>> Delete(Guid credentialId)
        {
            try
            {
                var response = await credentialService.DeleteCredential(credentialId);

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