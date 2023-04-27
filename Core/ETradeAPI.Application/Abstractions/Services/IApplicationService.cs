using ETradeAPI.Application.DTOs.Configuration;

namespace ETradeAPI.Application.Abstractions.Services
{
    public interface IApplicationService
    {
        List<Menu> GetAuthorizeDefinitionEndpoints(Type type);
    }
}
