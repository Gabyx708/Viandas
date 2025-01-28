using Viandas.Domain.Core.AggregatesModel.OrderAggregate;
using Viandas.Domain.Core.AggregatesModel.UserAggregate;

namespace Viandas.Domain.Core.AggregatesModel.MenuAggregate
{
    public class Menu
    {
        public string MenuID { get; private set; }
        public string UserResponsibleId { get; private set; }
        public DateTime ConsumptionDate { get; private set; }
        public DateTime OrderDeadLine { get; private set; }
        public DateTime CreationDate { get; private set; }
        private User _user;

        public List<MenuOption> Options { get; private set; }
        public List<Order> Orders { get; private set; }

        public Menu(User responsible, DateTime consumptionDate, DateTime orderDeadLine, DateTime creationDate)
        {
            ConsumptionDate = consumptionDate;
            CreationDate = creationDate;
            OrderDeadLine = orderDeadLine;

            _user = responsible;
            UserResponsibleId = responsible.Id;
            MenuID = CreateMenuId();

            Options = new List<MenuOption>();
            Orders = new List<Order>();
        }

        private string CreateMenuId()
        {
            return $"{CreationDate.ToString("yyyyMMddHHmmss")}";
        }

        public List<MenuOption> GetOptions()
        {
            return this.Options;
        }

        public void AddOption(Dish dish, int stock)
        {
            var option = new MenuOption(MenuID, dish, stock);
            this.Options.Add(option);
        }

        public void Cancel()
        {
           // this.orders.Select(o => o.Cancel)
        }


    }
}
