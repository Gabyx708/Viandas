using Viandas.Domain.Core.AggregatesModel.OrderAggregate;
using Viandas.Infrastructure.Data.EntityModels;
using Viandas.Infrastructure.Data.EntityModels.OrderModels;

namespace Viandas.Infrastructure.Data.EntityModel
{
    public class OrderModel
    {
        public required string OrderID { get; set; }
        public required string UserID { get; set; }
        public required string DiscountID { get; set; }
        public required Order.OrderStatus OrderStatus { get; set; }
        public DateTime CreationDate { get; set; }

        public required UserModel UserModel { get; set; }
        public required DiscountModel DiscountModel { get; set; }
        public required virtual ICollection<OrderItemModel> Items { get; set; }
        public required virtual ICollection<OrderTransitionModel> Transitions { get; set; }
    }
}
