using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETradeAPI.Persistence.Contexts;
using ETradeAPI.Persistence.Repositories;

namespace ETicaretAPI.Persistence.Repositories
{
    public class EndpointReadRepository : ReadRepository<Endpoint>, IEndpointReadRepository
    {
        public EndpointReadRepository(ETradeAPIDbContext context) : base(context)
        {
        }
    }
}