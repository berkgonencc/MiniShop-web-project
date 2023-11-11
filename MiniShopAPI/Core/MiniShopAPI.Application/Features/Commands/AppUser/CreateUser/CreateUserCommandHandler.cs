using System;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MiniShopAPI.Application.Abstractions.Services;
using MiniShopAPI.Application.DTOs.User;
using MiniShopAPI.Application.Exceptions;

namespace MiniShopAPI.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserResponse response = await _userService.CreateAsync(new()
            {
                Email = request.Email,
                FullName = request.FullName,
                Password = request.Password,
                ConfirmPassword = request.ConfirmPassword,
                UserName = request.UserName
            });

            return new()
            {
                Message = response.Message,
                Succeeded = response.Succeeded
            };
        }
    }
}

