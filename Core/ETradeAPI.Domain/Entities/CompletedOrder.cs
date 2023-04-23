using ETradeAPI.Domain.Entities.Common;

namespace ETradeAPI.Domain.Entities
{
    public class CompletedOrder : BaseEntity
    {
        public Guid OrderId { get; set; }

        public Order Order { get; set; }
    }
}
