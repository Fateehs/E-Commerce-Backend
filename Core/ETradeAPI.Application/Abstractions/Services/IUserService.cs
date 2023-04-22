using ETradeAPI.Application.DTOs.User;
using ETradeAPI.Domain.Entities.Identity;

namespace ETradeAPI.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAsync(CreateUser model);
        Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int refreshTokenLifeTime);
        Task UpdatePasswordAsync(string userId, string resetToken, string newPassword);
    }
}
