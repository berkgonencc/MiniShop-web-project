using System;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MiniShopAPI.Application.Abstractions.Services;
using MiniShopAPI.Application.Abstractions.Token;
using MiniShopAPI.Application.DTOs;
using MiniShopAPI.Application.Exceptions;
using MiniShopAPI.Application.Features.Commands.LoginUser;
using MiniShopAPI.Domain.Entities.Identity;

namespace MiniShopAPI.Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        readonly SignInManager<Domain.Entities.Identity.AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime)
        {
            Domain.Entities.Identity.AppUser user = await _userManager.FindByNameAsync(usernameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(usernameOrEmail);
            if (user == null)
                throw new NotFoundUserException();

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            // Authentication Successfull!
            if (result.Succeeded)
            {
                Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime);
                return token;

            }
            //return new LoginUserErrorCommandResponse() { Message = "Username or password is wrong!" };
            throw new AuthenticationErrorException();
        }
    }
}

