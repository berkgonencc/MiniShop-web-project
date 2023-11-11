using System;
namespace MiniShopAPI.Application.Abstractions.Services.Authentications
{
	public interface IInternalAuth
	{
		Task<DTOs.Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime);
	}
}

