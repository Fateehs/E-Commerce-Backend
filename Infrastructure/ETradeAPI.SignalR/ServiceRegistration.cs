using ETradeAPI.Application.Abstractions.Hubs;
using ETradeAPI.SignalR.HubServices;
using Microsoft.Extensions.DependencyInjection;

namespace ETradeAPI.SignalR
{
    public static class ServiceRegistration
    {
        public static void AddSignalRServices(this IServiceCollection services)
        {
            services.AddTransient<IProductHubService, ProductHubService>();
            services.AddTransient<IOrderHubService, OrderHubService>();
            services.AddSignalR();
        }
    }
}
