using Viandas.Domain.Core.AggregatesModel.OrderAggregate;
using Viandas.Infrastructure.Data.EntityModel;

namespace Viandas.Infrastructure.Data.EntityModels.OrderModels
{
    public class OrderTransitionModel
    {
        public required string OrderID { get; set; }
        public required string UserID { get; set; }
        public Order.OrderStatus FromStatus { get; set; }
        public Order.OrderStatus ToStatus { get; set; }
        public DateTime Date { get; set; }
        public string? Note { get; set; }
        public required OrderModel OrderModel { get; set; }
        public required UserModel UserModel { get; set; }

    }
}
