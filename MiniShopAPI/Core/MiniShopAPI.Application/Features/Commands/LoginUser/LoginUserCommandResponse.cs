using System;
using MiniShopAPI.Application.DTOs;

namespace MiniShopAPI.Application.Features.Commands.LoginUser
{
	public class LoginUserCommandResponse
	{
	}

	public class LoginUserSuccessCommandResponse : LoginUserCommandResponse
	{
        public Token Token { get; set; }

    }
    public class LoginUserErrorCommandResponse : LoginUserCommandResponse
	{
		public string Message { get; set; }
	}
}

