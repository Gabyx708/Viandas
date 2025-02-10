using Viandas.Domain.Core.AggregatesModel.MenuAggregate;
using Viandas.Domain.Core.AggregatesModel.OrderAggregate;
using Viandas.Infrastructure.Data.EntityModels;

namespace Viandas.Infrastructure.Data.EntityModel
{
    public class MenuModel : IEntityModel<Menu,MenuModel>
    {
        public string MenuID { get; set; } = null!;
        public string UserResponsibleId { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public DateTime ConsumptionDate { get; set; }
        public DateTime OrderDeadLine { get; set; }
        public UserModel Responsible { get; set; } = null!;
        public virtual ICollection<MenuOptionModel> Options { get; set; } = null!;
        public virtual ICollection<OrderModel> Orders { get; set; } = null!;

        public  Menu MapToEntity()
        {
            return new Menu(menuId: MenuID,
                            user: Responsible.MapToEntity(),
                            consumptionDate: ConsumptionDate.ToLocalTime(),
                            orderDeadLine: OrderDeadLine.ToLocalTime(),
                            creationDate: CreationDate.ToLocalTime(),
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
                CreationDate = entity.CreationDate.ToUniversalTime(),
                ConsumptionDate = entity.ConsumptionDate.ToUniversalTime(),
                OrderDeadLine = entity.OrderDeadLine.ToUniversalTime(),
                Responsible = null,
                Options = entity.GetOptions().Select(op => new MenuOptionModel().MapToModel(op)),
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
