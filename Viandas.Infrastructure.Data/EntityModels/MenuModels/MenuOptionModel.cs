using Viandas.Domain.Core.AggregatesModel.MenuAggregate;
using Viandas.Infrastructure.Data.EntityModels;

namespace Viandas.Infrastructure.Data.EntityModel
{
    public class MenuOptionModel : IEntityModel<MenuOption,MenuOptionModel>
    {
        public required string MenuID { get; set; }
        public required string DishID { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int RequestedQuantity { get; set; }

        public required DishModel Dish { get; set; }
        public required MenuModel Menu { get; set; }

        public required virtual ICollection<OrderItemModel> OrderItemModels { get; set; }

        public MenuOption MapToEntity()
        {
            throw new NotImplementedException();
        }

        public MenuOptionModel MapToModel(MenuOption entity)
        {
            throw new NotImplementedException();
        }
    }
}
