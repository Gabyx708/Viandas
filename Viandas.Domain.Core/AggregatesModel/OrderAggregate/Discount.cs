using Viandas.Domain.Core.Exceptions;

namespace Viandas.Domain.Core.AggregatesModel.OrderAggregate
{
    public class Discount
    {
        private string _discountID;
        private DateTime _creationDate;
        private string _userID;
        private decimal _amount;

        public Discount(string discountId,string userId,decimal amount)
        {
            if(amount < 1)
            {
                throw new ViandasDomainCoreException("the discount must be greater than 1%");
            }

            _discountID = discountId;
            _userID = userId;
            _creationDate = DateTime.Now;
        }

        public decimal GetAmount()
        {
            return _amount;
        }
    }
}
