using System;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MiniShopAPI.Application.Abstractions.Services;
using MiniShopAPI.Application.DTOs.User;
using MiniShopAPI.Application.Features.Commands.AppUser.CreateUser;
using MiniShopAPI.Domain.Entities.Identity;

namespace MiniShopAPI.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponse> CreateAsync(CreateUser request)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = request.UserName,
                FullName = request.FullName,
                Email = request.Email,

            }, request.Password);

            CreateUserResponse response = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
            {
                response.Message = "User is created successfully.";
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    response.Message += $"{error.Code} - {error.Description}\n";
                }
            }
            return response;
        }
    }
}

