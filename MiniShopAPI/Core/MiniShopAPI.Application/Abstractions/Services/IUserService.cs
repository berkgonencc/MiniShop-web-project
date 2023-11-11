using System;
using MiniShopAPI.Application.DTOs.User;

namespace MiniShopAPI.Application.Abstractions.Services
{
	public interface IUserService
	{
		Task<CreateUserResponse> CreateAsync(CreateUser model);
	}
}

