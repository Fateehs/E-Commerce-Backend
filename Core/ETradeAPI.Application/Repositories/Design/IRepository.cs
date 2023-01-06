using ETradeAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace ETradeAPI.Application.Repositories.Design
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
