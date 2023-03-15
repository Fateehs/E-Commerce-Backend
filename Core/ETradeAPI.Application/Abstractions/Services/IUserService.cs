using ETradeAPI.Application.DTOs.User;
using ETradeAPI.Domain.Entities.Identity;

namespace ETradeAPI.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAsync(CreateUser model);
        Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int refreshTokenLifeTime);
    }
}
