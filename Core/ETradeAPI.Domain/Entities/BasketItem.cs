using ETradeAPI.Domain.Entities.Common;

namespace ETradeAPI.Domain.Entities
{
    public class BasketItem : BaseEntity
    {
        public Guid BasketId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public Basket Basket { get; set; } // Each basket item can have "1" basket
        public Product Product { get; set; } // Each basket item can have "1" product
    }
}
