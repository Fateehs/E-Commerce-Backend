using ETradeAPI.Application.Repositories;
using ETradeAPI.Domain.Entities;
using ETradeAPI.Persistence.Contexts;

namespace ETradeAPI.Persistence.Repositories
{
    public class CompletedOrderReadRepository : ReadRepository<CompletedOrder>, ICompletedOrderReadRepository
    {
        public CompletedOrderReadRepository(ETradeAPIDbContext context) : base(context)
        {
        }
    }
}
