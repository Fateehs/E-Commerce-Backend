using ETradeAPI.Application.Abstractions.Services;
using ETradeAPI.Application.ViewModels.Baskets;
using ETradeAPI.Domain.Entities;

namespace ETradeAPI.Persistence.Services
{
    public class BasketService : IBasketService
    {
        public Task AddItemToBasketAsync(VM_Create_BasketItem basketItem)
        {
            throw new NotImplementedException();
        }

        public Task<List<BasketItem>> GetBasketItemAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveBasketItemAsync(string basketItemId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateQuantityAsync(VM_Update_BasketItem basketItem)
        {
            throw new NotImplementedException();
        }
    }
}
