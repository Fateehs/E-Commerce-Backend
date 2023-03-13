using ETradeAPI.Application.Abstractions.Services.Authentications;

namespace ETradeAPI.Application.Abstractions.Services
{
    public interface IAuthService : IExternalAuthentication,IInternalAuthentication
    {
 
    }
}
