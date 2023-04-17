using System;
using System.Threading.Tasks;
using Dev33.UltimateTeam.Api.Services.LoggerService;
using Dev33.UltimateTeam.Application.Contracts.Services;
using Dev33.UltimateTeam.Application.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UltimateTeam.Api.Controllers
{
    [Route("api/users/{userId:guid}/containers/{containerId:guid}/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class KeyController : ControllerBase
    {
        private IKeyService keyService;
        private readonly ILoggerManager loggerManager;

        public KeyController(IKeyService keyService, ILoggerManager loggerManager)
        {
            this.keyService = keyService;
            this.loggerManager = loggerManager;
        }

        [HttpGet("{keyId:guid}")]
        public async Task<ActionResult<KeyResponseDto>> GetById(Guid keyId)
        {
            try
            {
                var response = await keyService.GetKeyById(keyId);

                return Ok(response);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<KeyResponseDto>> Create(KeyRequestDto key)
        {
            try
            {
                var response = await keyService.CreateKey(key);

                return Ok(response);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{keyId:guid}")]
        public async Task<ActionResult<KeyResponseDto>> Update(Guid keyId, KeyRequestDto key)
        {
            try
            {
                var response = await keyService.UpdateKey(key, keyId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{keyId:guid}")]
        public async Task<ActionResult<KeyResponseDto>> Delete(Guid keyId)
        {
            try
            {
                var response = await keyService.DeleteKey(keyId);

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