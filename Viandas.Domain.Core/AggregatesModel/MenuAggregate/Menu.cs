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

        public string Id => _menuID;
        public string UserID => _userResponsibleId;
        public IReadOnlyCollection<MenuOption> Options => _options;
        public IReadOnlyCollection<Order> Orders => _orders;

        private List<MenuOption> _options;
        private List<Order> _orders;

        public Menu(User responsible, DateTime consumptionDate, DateTime orderDeadLine, DateTime creationDate)
        {
            _consumptionDate = consumptionDate;
            _creationDate = creationDate;
            _orderDeadLine = orderDeadLine;

            _user = responsible;
            _userResponsibleId = responsible.GetId();
            _menuID = CreateMenuId();

            _options = new List<MenuOption>();
            _orders = new List<Order>();
        }

        public Menu(string menuId,
                    User user,
                    DateTime consumptionDate,
                    DateTime orderDeadLine,
                    DateTime creationDate,
                    List<Order> orders,
                    List<MenuOption> options)
        {
            this._menuID = menuId;
            this._userResponsibleId = user.GetId();
            this._user = user;
            this._consumptionDate = consumptionDate;
            this._orderDeadLine = orderDeadLine;
            this._creationDate = creationDate;
            this._orders = orders;
            this._options = options;
        }

        private string CreateMenuId()
        {
            return $"{_creationDate.ToString("yyyyMMddHHmmss")}";
        }

        public List<MenuOption> GetOptions()
        {
            return this._options;
        }

        public void AddOption(Dish dish, int stock)
        {
            var option = new MenuOption(_menuID, dish, stock);
            this._options.Add(option);
        }

        public void Cancel()
        {
           // this.orders.Select(o => o.Cancel)
        }


    }
}
