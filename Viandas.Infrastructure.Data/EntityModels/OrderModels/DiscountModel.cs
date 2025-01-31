using System.Collections.ObjectModel;
using Viandas.Infrastructure.Data.EntityModel;

namespace Viandas.Infrastructure.Data.EntityModels.OrderModels
{
    public class DiscountModel
    {
        public required string DiscountID { get; set; }
        public DateTime CreationDate { get; set; }
        public required string UserID { get; set; }
        public decimal Amount { get; set; }

        public required virtual UserModel User { get; set; }
        public required virtual Collection<OrderModel> OrderModels { get; set; }
    }
}
