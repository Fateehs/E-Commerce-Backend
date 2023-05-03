using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETradeAPI.Persistence.Contexts;
using ETradeAPI.Persistence.Repositories;

namespace ETicaretAPI.Persistence.Repositories
{
    public class MenuWriteRepository : WriteRepository<Menu>, IMenuWriteRepository
    {
        public MenuWriteRepository(ETradeAPIDbContext context) : base(context)
        {
        }
    }
}