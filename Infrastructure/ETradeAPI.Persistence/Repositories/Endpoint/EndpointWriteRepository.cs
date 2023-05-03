using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETradeAPI.Persistence.Contexts;
using ETradeAPI.Persistence.Repositories;

namespace ETicaretAPI.Persistence.Repositories
{
    public class EndpointWriteRepository : WriteRepository<Endpoint>, IEndpointWriteRepository
    {
        public EndpointWriteRepository(ETradeAPIDbContext context) : base(context)
        {
        }
    }
}
