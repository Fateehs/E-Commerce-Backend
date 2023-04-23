using ETradeAPI.Domain.Entities.Common;

namespace ETradeAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        //public Guid CustomerId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string OrderCode { get; set; }

        public Basket Basket { get; set; } // Each order can have "1" basket
        //public ICollection<Product> Products { get; set; }
        //public Customer Customer { get; set; }
        public CompletedOrder CompletedOrder { get; set; }
    }
}
