using MiniShopAPI.Domain.Entities.Identity;

namespace MiniShopAPI.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        DTOs.Token CreateAccessToken(int minute, AppUser user);
    }
}

