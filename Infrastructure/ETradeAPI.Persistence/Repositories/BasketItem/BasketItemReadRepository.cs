using ETradeAPI.Application.Repositories;
using ETradeAPI.Persistence.Contexts;

namespace ETradeAPI.Persistence.Repositories
{
    public class BasketItemReadRepository : ReadRepository<Domain.Entities.BasketItem>, IBasketItemReadRepository
    {
        public BasketItemReadRepository(ETradeAPIDbContext context) : base(context)
        {
        }
    }
}
