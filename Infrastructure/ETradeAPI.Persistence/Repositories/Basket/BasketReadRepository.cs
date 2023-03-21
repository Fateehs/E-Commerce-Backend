using ETradeAPI.Application.Repositories;
using ETradeAPI.Persistence.Contexts;

namespace ETradeAPI.Persistence.Repositories
{
    public class BasketReadRepository : ReadRepository<Domain.Entities.Basket>, IBasketReadRepository
    {
        public BasketReadRepository(ETradeAPIDbContext context) : base(context)
        {
        }
    }
}
