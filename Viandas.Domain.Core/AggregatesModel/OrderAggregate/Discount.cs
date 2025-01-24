using Viandas.Domain.Core.Exceptions;

namespace Viandas.Domain.Core.AggregatesModel.OrderAggregate
{
    public class Discount
    {
        public string DiscountID { get; private set; }
        public DateTime CreationDate { get; private set; }
        public string UserID { get; private set; }
        public decimal Amount { get;private set; }

        public Discount(string discountId,string userId,decimal amount)
        {
            if(amount < 1)
            {
                throw new ViandasDomainCoreException("the discount must be greater than 1%");
            }

            DiscountID = discountId;
            UserID = userId;
            CreationDate = DateTime.Now;
        }

        public decimal GetAmount()
        {
            return Amount;
        }
    }
}
