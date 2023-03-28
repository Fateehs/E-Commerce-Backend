using ETradeAPI.Application.DTOs.Order;

namespace ETradeAPI.Application.Abstractions.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(CreateOrder createOrder);
    }
}
