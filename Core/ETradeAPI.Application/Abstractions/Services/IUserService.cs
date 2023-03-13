using ETradeAPI.Application.DTOs.User;

namespace ETradeAPI.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAsync(CreateUser model);
    }
}
