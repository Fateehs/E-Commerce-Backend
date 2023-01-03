using ETradeAPI.Application.Abstractions;
using ETradeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistence.Concretes
{
    public class ProductManager : IProductService
    {
        public List<Product> GetAll()
            => new() 
            {
            new(){ Id = Guid.NewGuid(), Name = "Product 1", Price = 100, Stock = 10 },
            new(){ Id = Guid.NewGuid(), Name = "Product 2", Price = 200, Stock = 10 },
            new(){ Id = Guid.NewGuid(), Name = "Product 3", Price = 300, Stock = 10 },
            new(){ Id = Guid.NewGuid(), Name = "Product 4", Price = 400, Stock = 10 },
            new(){ Id = Guid.NewGuid(), Name = "Product 5", Price = 500, Stock = 10 },
            };
    }
}
