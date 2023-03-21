using ETradeAPI.Application.ViewModels.Baskets;
using ETradeAPI.Domain.Entities;

namespace ETradeAPI.Application.Abstractions.Services
{
    public interface IBasketService
    {
        public Task<List<BasketItem>> GetBasketItemAsync();
        public Task AddItemToBasketAsync(VM_Create_BasketItem basketItem);
        public Task UpdateQuantityAsync(VM_Update_BasketItem basketItem);
        public Task RemoveBasketItemAsync(string basketItemId);
    }
}
