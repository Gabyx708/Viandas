using Viandas.Domain.Core.Exceptions;

namespace Viandas.Domain.Core.AggregatesModel.MenuAggregate
{
    public class MenuOption
    {
        private string _menuID;
        private string _dishID;
        private int _stock;
        private int _requestedQuantity;
        private decimal _price;

        public string MenuID => _menuID;
        public string DishID => _dishID;
        public int Stock => _stock;
        private readonly Dish _dish;

        public MenuOption(string menuId, Dish dish, int stock)
        {
            _menuID = menuId;
            _dishID = dish.Id;

            _dish = dish;
            _price = dish.GetPrice();
            _stock = CheckStockIsValid(stock);
        }

        public MenuOption(string menuID, string dishID, int stock, int requestedQuantity, decimal price)
        {
            _menuID = menuID;
            _dishID = dishID;
            _stock = stock;
            _requestedQuantity = requestedQuantity;
            _price = price;
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

            if (_stock < quantity)
            {
                throw new ViandasDomainCoreException("insufficient stock");
            }

            _requestedQuantity += quantity;
            _stock -= quantity;
        }

        public string GetDescription()
        {
            return "T"; //TODO: agrega a la interfaz de dish la capacidad de devolver su descripcion
        }

        public decimal GetPrice()
        {
            return _dish.GetPrice();
        }

    }
}
