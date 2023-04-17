using System;
using System.Threading.Tasks;
using Dev33.UltimateTeam.Api.Services.LoggerService;
using Dev33.UltimateTeam.Application.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UltimateTeam.Application.Contracts.Services;
using UltimateTeam.Application.Dtos;

namespace UltimateTeam.Api.Controllers
{
    [Route("api/users/{userId:guid}/containers/{containerId:guid}/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly ICreditCardService creditCardService;
        private readonly ILoggerManager loggerManager;

        public CreditCardController(ICreditCardService creditCardService, ILoggerManager loggerManager)
        {
            this.creditCardService = creditCardService;
            this.loggerManager = loggerManager;
        }

        [HttpGet("{creditCardId:guid}")]
        public async Task<ActionResult<CreditCardResponseDto>> GetById(Guid creditCardId)
        {
            try
            {
                var response = await creditCardService.GetCreditCardById(creditCardId);

                return Ok(response);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CreditCardResponseDto>> Create(CreditCardRequestDto contact)
        {
            try
            {
                var response = await creditCardService.CreateCard(contact);

                return Ok(response);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{creditCardId:guid}")]
        public async Task<ActionResult<CreditCardResponseDto>> Update(Guid creditCardId, CreditCardRequestDto creditCard)
        {
            try
            {
                var response = await creditCardService.UpdateCard(creditCard, creditCardId);

                return Ok(response);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{creditCardId:guid}")]
        public async Task<ActionResult<CreditCardResponseDto>> Delete(Guid creditCardId)
        {
            try
            {
                var response = await creditCardService.DeleteCard(creditCardId);

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