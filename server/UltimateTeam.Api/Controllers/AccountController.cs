using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Dev33.UltimateTeam.Application.Contracts.Services;
using Dev33.UltimateTeam.Application.Dtos;
using Dev33.UltimateTeam.Application.Encyptors;
using Dev33.UltimateTeam.Domain.Models;
using Dev33.UltimateTeam.Api.Services.LoggerService;
using AutoMapper;
using Dev33.UltimateTeam.Domain;

namespace Dev33.UltimateTeam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAuthenticateService authenticateService;
        private IEncryptor encryptor;
        private readonly ILoggerManager loggerManager;
        private IMapper mapper;

        public AccountController(IAuthenticateService authenticateService, ILoggerManager loggerManager, IMapper mapper)
        {
            this.authenticateService = authenticateService;
            encryptor = new MD5Encryptor();
            this.loggerManager = loggerManager;
            this.mapper = mapper;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<UserResponseDto>> Authenticate(UserRequestDto request)
        {
            try
            {
                request.Password = encryptor.EncryptData(request.Password);
                var user = await authenticateService.AuthenticateAsync(request.Email, request.UserName, request.Password);
                var userResponse = mapper.Map<UserResponseDto>(user);
                userResponse.Token = GenerateToken(userResponse);

                return Ok(userResponse);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);

                return BadRequest(ex.Message);
            }
        }

        private string GenerateToken(UserResponseDto user)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FullName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var payload = new JwtPayload
            (
                issuer: "UltimateTeam",
                audience: "UltimateTeam",
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(100)
            );

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserResponseDto>> Register(User request)
        {
            try
            {
                request.Password = encryptor.EncryptData(request.Password);
                var user = await authenticateService.RegisterAsync(request);
                var userResponse = mapper.Map<UserResponseDto>(user);
                userResponse.Token = GenerateToken(userResponse);

                return Ok(userResponse);
            }
            catch (Exception ex)
            {
                loggerManager.LogError(ex);

                return BadRequest(new { message = "Username or email already exists" });
            }
        }
    }
}