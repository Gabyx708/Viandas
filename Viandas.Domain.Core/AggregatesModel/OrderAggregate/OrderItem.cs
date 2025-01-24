using Viandas.Domain.Core.AggregatesModel.MenuAggregate;

namespace Viandas.Domain.Core.AggregatesModel.OrderAggregate
{
    public class OrderItem
    {
        public string MenuID { get; private set; }
        public string DishID { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Units { get; private set; }


        public OrderItem(MenuOption option, int units)
        {
            option.TakeQuantity(units);

            MenuID = option.MenuID;
            DishID = option.DishID;
            Price = option.GetPrice();
            Description = option.GetDescription();
        }

        public decimal GetTotalPrice()
        {
            return Price * Units;
        }
    }
}
