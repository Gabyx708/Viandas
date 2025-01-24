using Viandas.Domain.Core.Exceptions;

namespace Viandas.Domain.Core.AggregatesModel.MenuAggregate
{
    public class Dish
    {
        public string Id { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string UserID { get; private set; }
        public DateTime CretionDate { get; private set; }

        public Dish(string id, string description, decimal price, string userID)
        {
            Id = id;
            Description = CheckDescriptionIsValid(description);
            Price = CheckPriceIsValid(price);
            UserID = userID;
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
            this.Price = CheckPriceIsValid(price);
        }

        public void ChangeDescription(string description)
        {
            this.Description = CheckDescriptionIsValid(description);
        }
    }
}
