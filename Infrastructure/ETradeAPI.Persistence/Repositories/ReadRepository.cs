using ETradeAPI.Application.Repositories;
using ETradeAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ETradeAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class
    {
        private readonly ETradeAPIDbContext _context;

        public ReadRepository(ETradeAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll() 
            => Table;

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression) 
            => Table.Where(expression);

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression) 
            => await Table.FirstOrDefaultAsync(expression);

        public Task<T> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
