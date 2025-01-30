using Viandas.Domain.Core.AggregatesModel.OrderAggregate;
using Viandas.Infrastructure.Data.EntityModels;

namespace Viandas.Infrastructure.Data.EntityModel
{
    public class OrderModel
    {
        public required string OrderID { get; set; }
        public required string UserID { get; set; }
        public required string DiscountID { get; set; }
        public required Order.OrderStatus OrderStatus { get; set; }
        public DateTime CreationDate { get; set; }

        public required UserModel User { get; set; }
        public required DiscountModel Discount { get; set; }
        public required virtual ICollection<OrderItemModel> Items { get; set; }
    }
}
