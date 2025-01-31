using Viandas.Domain.Core.AggregatesModel.MenuAggregate;
using Viandas.Domain.Core.AggregatesModel.OrderAggregate;
using Viandas.Infrastructure.Data.EntityModels;

namespace Viandas.Infrastructure.Data.EntityModel
{
    public class MenuModel : IEntityModel<Menu,MenuModel>
    {
        public required string MenuID { get; set; }
        public required string UserResponsibleId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ConsumptionDate { get; set; }
        public DateTime OrderDeadLine { get; set; }
        public required UserModel Responsible { get; set; }
        public required virtual ICollection<MenuOptionModel> Options { get; set; }
        public required virtual ICollection<OrderModel> Orders { get; set; }

        public  Menu MapToEntity()
        {
            return new Menu(menuId: MenuID,
                            user: Responsible.MapToEntity(),
                            consumptionDate: ConsumptionDate,
                            orderDeadLine: OrderDeadLine,
                            creationDate: CreationDate,
                            orders: MapOrderModelsToOrders(),
                            options: MapModelMenuOptionToMenuOption()
                            );
        }

        public  MenuModel MapToModel(Menu entity)
        {
            return new MenuModel
            {
                MenuID = entity.Id,
                UserResponsibleId = entity._userResponsibleId,
                CreationDate = entity.CreationDate,
                ConsumptionDate = entity.ConsumptionDate,
                OrderDeadLine = entity.OrderDeadLine,
                Responsible = null,
                Options = null,
                Orders = entity.Orders.Select(o => new OrderModel().MapToModel(o)).ToList()
            };
        }

        private List<Order> MapOrderModelsToOrders()
        {
            return Orders.Select(o => o.MapToEntity()).ToList();
        }

        private List<MenuOption> MapModelMenuOptionToMenuOption()
        {
            return Options.Select(op => op.MapToEntity()).ToList();
        }
    }
}
