using Viandas.Domain.Core.Exceptions;

namespace Viandas.Domain.Core.AggregatesModel.MenuAggregate
{
    public class Dish
    {
        private string _dishID;
        private string _description;
        private decimal _price;
        private string _userID;
        private DateTime _creationDate;

        public Dish(string id, string description, decimal price, string userID)
        {
            _dishID = id;
            _description = CheckDescriptionIsValid(description);
            _price = CheckPriceIsValid(price);
            _userID = userID;
        }

        private string CheckDescriptionIsValid(string description)
        {
            if (description.Length < 5)
            {
                throw new ViandasDomainCoreException("the description is too short");
            }

            return description;
        }

        private decimal CheckPriceIsValid(decimal price)
        {
            if (price < 0)
            {
                throw new ViandasDomainCoreException("the price must be greater than zero");
            }

            return price;
        }

        public void ChangePrice(decimal price)
        {
            this._price = CheckPriceIsValid(price);
        }

        public void ChangeDescription(string description)
        {
            this._description = CheckDescriptionIsValid(description);
        }
    }
}
