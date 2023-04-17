using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dev33.UltimateTeam.Application.Contracts.Repositories;
using Dev33.UltimateTeam.Application.Contracts.Services;
using Dev33.UltimateTeam.Application.Dtos;
using Dev33.UltimateTeam.Domain.Models;

namespace Dev33.UltimateTeam.Application.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IUnitOfWork unitOfWork;

        public AuthenticateService(IUnitOfWork unitOfWork)
        { 
            this.unitOfWork = unitOfWork;
        }

        public async Task<User> AuthenticateAsync(string email, string userName, string password)
        {
            var userExists = await unitOfWork.UserRepository.GetByEmailAsync(email)
                ?? await unitOfWork.UserRepository.GetByUserNameAsync(userName);
            
            if (userExists == null)
            {
                throw new Exception("User not found");
            }

            if (!userExists.Password.Equals(password))
            {
                throw new Exception("Password is incorrect");
            }

            return userExists;
        }

        public async Task<User> RegisterAsync(User request)
        {
            var user = await unitOfWork.UserRepository.GetByEmailAsync(request.Email)
                ?? await unitOfWork.UserRepository.GetByUserNameAsync(request.UserName);

            if (user != null)
            {
                throw new Exception("User already exists");
            }

            await unitOfWork.UserRepository.AddAsync(request);

            return request;
        }
    }
}
