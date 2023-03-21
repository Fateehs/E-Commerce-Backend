using ETradeAPI.Application.Repositories.BasketItem;
using ETradeAPI.Persistence.Contexts;

namespace ETradeAPI.Persistence.Repositories
{
    public class BasketItemWriteRepository : WriteRepository<Domain.Entities.BasketItem>, IBasketItemWriteRepository
    {
        public BasketItemWriteRepository(ETradeAPIDbContext context) : base(context)
        {
        }
    }
}
