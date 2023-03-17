using ETradeAPI.Application.Abstractions.Services;
using ETradeAPI.Application.Abstractions.Token;
using ETradeAPI.Application.DTOs;
using ETradeAPI.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ETradeAPI.Application.Features.Commands.AppUser.LoginUser
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
            var token = await _authService.LoginAsync(request.UsernameOrEmail, request.Password, 900);

            return new LoginUserSuccessCommandResponse()
            {
                Token = token
            };
        }
    }
}
