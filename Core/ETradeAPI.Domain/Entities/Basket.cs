using ETradeAPI.Domain.Entities.Common;
using ETradeAPI.Domain.Entities.Identity;

namespace ETradeAPI.Domain.Entities
{
    public class Basket : BaseEntity
    {
        public string UserId { get; set; }

        public AppUser User { get; set; } // Each basket can have "1" user
        public Order Order { get; set; } // Each basket can have "1" order
        public ICollection<BasketItem> BasketItems { get; set; } // Each basket can have "n" basket item
    }
}
