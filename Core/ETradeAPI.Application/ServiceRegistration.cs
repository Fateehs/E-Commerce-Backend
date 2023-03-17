using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;

namespace ETradeAPI.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services) 
        {
            services.AddMediatR(typeof(ServiceRegistration));
            services.AddHttpClient();
        }
    }
}
