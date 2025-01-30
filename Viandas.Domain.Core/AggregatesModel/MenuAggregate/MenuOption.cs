using Viandas.Domain.Core.Exceptions;

namespace Viandas.Domain.Core.AggregatesModel.MenuAggregate
{
    public class MenuOption
    {
        private string _menuID;
        private string _dishID;
        private int Stock;
        private int _requestedQuantity;
        private decimal _price;

        private readonly Dish _dish;

        public MenuOption(string menuId, Dish dish, int stock)
        {
            _menuID = menuId;
            _dishID = dish._dishID;

            _dish = dish;
            _price = dish._price;
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

            _requestedQuantity += quantity;
            Stock -= quantity;
        }

        public string GetDescription()
        {
            return _dish._description;
        }

        public decimal GetPrice()
        {
            return _dish._price;
        }
    }
}
