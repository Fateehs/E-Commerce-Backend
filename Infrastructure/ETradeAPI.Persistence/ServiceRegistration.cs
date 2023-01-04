using ETradeAPI.Application.Abstractions;
using ETradeAPI.Persistence.Concretes;
using ETradeAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ETradeAPIDbContext>
                (options => options.UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=ETradeAPIDb;"));
        }
    }
}
