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
    public class ContactController : ControllerBase
    {
        private IContactService contactService;
        private readonly ILoggerManager loggerManager;

        public ContactController(IContactService contactService, ILoggerManager loggerManager)
        {
            this.contactService = contactService;
            this.loggerManager = loggerManager;
        }

        [HttpGet("{contactId:guid}")]
        public async Task<ActionResult<ContactResponseDto>> GetById(Guid contactId)
        {
            try
            {
                var response = await contactService.GetContactById(contactId);

                return Ok(response);
            }

            catch (Exception ex)
            {
                loggerManager.LogError(ex);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ContactResponseDto>> Create(ContactRequestDto contact)
        {
            try
            {
                var response = await contactService.CreateContact(contact);

                return Ok(response);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{contactId:guid}")]
        public async Task<ActionResult<ContactResponseDto>> Update(Guid contactId, ContactRequestDto contact)
        {
            try
            {
                var response = await contactService.UpdateContact(contact, contactId);

                return Ok(response);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{contactId:guid}")]
        public async Task<ActionResult<ContactResponseDto>> Delete(Guid contactId)
        {
            try
            {
                var response = await contactService.DeleteContact(contactId);

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