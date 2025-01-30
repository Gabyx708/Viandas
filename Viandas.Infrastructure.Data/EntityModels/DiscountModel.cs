using Viandas.Infrastructure.Data.EntityModel;

namespace Viandas.Infrastructure.Data.EntityModels
{
    public class DiscountModel
    {
        public required string DiscountID { get; set; }
        public DateTime CreationDate { get; set; }
        public required string UserID { get; set; }
        public decimal Amount { get; set; }

        public required virtual UserModel User { get; set; }
    }
}
