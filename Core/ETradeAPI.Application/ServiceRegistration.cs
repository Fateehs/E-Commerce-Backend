using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ETradeAPI.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services) 
        {
            services.AddMediatR(typeof(ServiceRegistration));
        }
    }
}
