using Viandas.Domain.Core.AggregatesModel.OrderAggregate;
using Viandas.Infrastructure.Data.EntityModels;
using Viandas.Infrastructure.Data.EntityModels.OrderModels;

namespace Viandas.Infrastructure.Data.EntityModel
{
    public class OrderModel : IEntityModel<Order,OrderModel>
    {
        public  string? OrderID { get; set; }
        public  string? UserID { get; set; }
        public  string? DiscountID { get; set; }
        public  Order.OrderStatus OrderStatus { get; set; }
        public DateTime CreationDate { get; set; }

        public  UserModel? UserModel { get; set; }
        public  DiscountModel? DiscountModel { get; set; }
        public  virtual ICollection<OrderItemModel>? Items { get; set; }
        public  virtual ICollection<OrderTransitionModel>? Transitions { get; set; }



        public Order MapToEntity()
        {
            throw new NotImplementedException();
        }

        public OrderModel MapToModel(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
