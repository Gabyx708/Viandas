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

        public string Id => _dishID;
        public string UserID => _userID;
        public string Description => _description;
        public DateTime CreationDate => _creationDate;

        public Dish(string id, string description, decimal price, string userID)
        {
            _dishID = id;
            _description = CheckDescriptionIsValid(description);
            _price = CheckPriceIsValid(price);
            _userID = userID;
            _creationDate = DateTime.Now;
        }

        public Dish(string dishID, string description, decimal price, string userID, DateTime creationDate)
        {
            _dishID = dishID;
            _description = description;
            _price = price;
            _userID = userID;
            _creationDate = creationDate;
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

        public decimal GetPrice()
        {
            return _price;
        }
    }
}
