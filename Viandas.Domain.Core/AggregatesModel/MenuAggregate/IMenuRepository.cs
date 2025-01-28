namespace Viandas.Domain.Core.AggregatesModel.MenuAggregate
{
    public interface IMenuRepository
    {
        Menu InsertMenu(Menu menu);
        Menu GetMenuById(string menuID);
        Menu GetMenuWithOrders(string menuID);
        IEnumerable<Menu> GetMenusBetweenTwoDates(DateTime firstDate, DateTime lastDate);
        Menu UpdateMenu(Menu menu);
    }
}
