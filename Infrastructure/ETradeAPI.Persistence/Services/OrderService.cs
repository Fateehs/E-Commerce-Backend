using ETradeAPI.Application.Abstractions.Services;
using ETradeAPI.Application.DTOs.Order;
using ETradeAPI.Application.Repositories;

namespace ETradeAPI.Persistence.Services
{
    public class OrderService : IOrderService
    {
        readonly IOrderWriteRepository _orderWriteRepository;

        public OrderService(IOrderWriteRepository orderWriteRepository)
        {
            _orderWriteRepository = orderWriteRepository;
        }

        public async Task CreateOrderAsync(CreateOrder createOrder)
        {
            await _orderWriteRepository.AddAsync(new()
            {
                Address = createOrder.Address,
                Id = Guid.Parse(createOrder.BasketId),
                Description = createOrder.Description,
            });

            await _orderWriteRepository.SaveAsync();
        }
    }
}
