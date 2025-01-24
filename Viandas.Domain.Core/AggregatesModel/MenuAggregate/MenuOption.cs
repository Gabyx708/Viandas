using Viandas.Domain.Core.Exceptions;

namespace Viandas.Domain.Core.AggregatesModel.MenuAggregate
{
    public class MenuOption
    {
        public string MenuID { get; private set; }
        public string DishID { get; private set; }
        public int Stock { get; private set; }
        public int RequestedQuantity { get; private set; }
        public decimal Price { get; private set; }

        private readonly Dish _dish;

        public MenuOption(string menuId, Dish dish, int stock)
        {
            MenuID = menuId;
            DishID = dish.Id;

            _dish = dish;
            Price = dish.Price;
            Stock = CheckStockIsValid(stock);
        }

        private int CheckStockIsValid(int stock)
        {
            if (stock < 1)
            {
                throw new ViandasDomainCoreException("stock must be greater than 1");
            }

            return stock;
        }

        public void TakeQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ViandasDomainCoreException("The quantity must be greater than zero.");
            }

            if (Stock < quantity)
            {
                throw new ViandasDomainCoreException("insufficient stock");
            }

            RequestedQuantity += quantity;
            Stock -= quantity;
        }

        public string GetDescription()
        {
            return _dish.Description;
        }

        public decimal GetPrice()
        {
            return _dish.Price;
        }
    }
}
