using Viandas.Domain.Core.AggregatesModel.MenuAggregate;

namespace Viandas.Infrastructure.Interface.IRepositories
{
    public interface IMenuRepository
    {
        Menu InsertMenu(Menu menu);
        Menu GetMenuById(string menuID);
        Menu GetMenuWithOrders(string menuID);
        List<Menu> GetMenusBetweenTwoDates(DateTime firstDate, DateTime lastDate);
        Menu UpdateMenu(Menu menu);
    }
}
