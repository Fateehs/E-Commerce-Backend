using ETradeAPI.Application.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ETradeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async void Get()
        {
            _productWriteRepository.AddRangeAsync(new()
            {
                new() {Id = Guid.NewGuid(), Name = "Product 1", Price =100 , CreatedDate= DateTime.UtcNow , Stock = 10},
                new() {Id = Guid.NewGuid(), Name = "Product 2", Price =102 , CreatedDate= DateTime.UtcNow , Stock = 23},
                new() {Id = Guid.NewGuid(), Name = "Product 3", Price =232 , CreatedDate= DateTime.UtcNow , Stock = 22}
            });
            await _productWriteRepository.SaveAsync();
        }
    }
}
