using Viandas.Domain.Core.AggregatesModel.OrderAggregate;
using Viandas.Domain.Core.AggregatesModel.UserAggregate;

namespace Viandas.Domain.Core.AggregatesModel.MenuAggregate
{
    public class Menu
    {
        private string _menuID;
        public string _userResponsibleId;
        private DateTime _consumptionDate;
        private DateTime _orderDeadLine;
        private DateTime _creationDate;
        private User _user;

        public List<MenuOption> Options { get; private set; }
        public List<Order> Orders { get; private set; }

        public Menu(User responsible, DateTime consumptionDate, DateTime orderDeadLine, DateTime creationDate)
        {
            _consumptionDate = consumptionDate;
            _creationDate = creationDate;
            _orderDeadLine = orderDeadLine;

            _user = responsible;
            _userResponsibleId = responsible._userID;
            _menuID = CreateMenuId();

            Options = new List<MenuOption>();
            Orders = new List<Order>();
        }

        private string CreateMenuId()
        {
            return $"{_creationDate.ToString("yyyyMMddHHmmss")}";
        }

        public List<MenuOption> GetOptions()
        {
            return this.Options;
        }

        public void AddOption(Dish dish, int stock)
        {
            var option = new MenuOption(_menuID, dish, stock);
            this.Options.Add(option);
        }

        public void Cancel()
        {
           // this.orders.Select(o => o.Cancel)
        }


    }
}
