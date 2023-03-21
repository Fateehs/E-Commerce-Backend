using ETradeAPI.Application.Repositories;
using ETradeAPI.Persistence.Contexts;

namespace ETradeAPI.Persistence.Repositories
{
    public class BasketWriteRepository : WriteRepository<Domain.Entities.Basket>, IBasketWriteRepository
    {
        public BasketWriteRepository(ETradeAPIDbContext context) : base(context)
        {
        }
    }
}
