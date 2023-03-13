using ETradeAPI.Application.Abstractions.Services;
using ETradeAPI.Application.DTOs.User;
using ETradeAPI.Application.Exceptions;
using ETradeAPI.Application.Features.Commands.AppUser.CreateUser;
using ETradeAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ETradeAPI.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponse> CreateAsync(CreateUser model)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.Username,
                Email = model.Email,
                NameSurname = model.NameSurname,
            }, model.Password);

            CreateUserResponse response = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
                response.Message = "User created successfully.";
            else
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code} - {error.Description}\n";

            return response;
        }

        public async Task UpdateRefreshToken(string refreshToken, string userId, DateTime accessTokenDate, int refreshTokenLifeTime)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);

            if(user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddMinutes(refreshTokenLifeTime);
                await _userManager.UpdateAsync(user);
            }
            throw new NotFoundUserException();
        }
    }
}
