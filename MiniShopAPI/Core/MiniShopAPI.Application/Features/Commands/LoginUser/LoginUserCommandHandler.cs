using System;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MiniShopAPI.Application.Abstractions.Services;
using MiniShopAPI.Application.Abstractions.Token;
using MiniShopAPI.Application.DTOs;
using MiniShopAPI.Application.Exceptions;

namespace MiniShopAPI.Application.Features.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly IAuthService _authService;

        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var token = await _authService.LoginAsync(request.UsernameOrEmail, request.Password, 10);
            return new LoginUserSuccessCommandResponse()
            {
                Token = token
            };
        }
    }
}

