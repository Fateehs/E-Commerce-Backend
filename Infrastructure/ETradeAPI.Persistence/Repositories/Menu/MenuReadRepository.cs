using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETradeAPI.Persistence.Contexts;
using ETradeAPI.Persistence.Repositories;

namespace ETicaretAPI.Persistence.Repositories
{
    public class MenuReadRepository : ReadRepository<Menu>, IMenuReadRepository
    {
        public MenuReadRepository(ETradeAPIDbContext context) : base(context)
        {
        }
    }
}