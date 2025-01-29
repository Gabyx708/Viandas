using Viandas.Domain.Core.AggregatesModel.OrderAggregate;

namespace Viandas.Infrastructure.Interface.IRepositories
{
    public interface IOrderRepository
    {
        Order GetOrderById(string orderId);
        Order InsertOrder(Order order);
        Order UpdateOrder(Order order);
        List<Order> GetUserOrders(string userID, DateTime firstDate, DateTime lastDate);
    }
}
