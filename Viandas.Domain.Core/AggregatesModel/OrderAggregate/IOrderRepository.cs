namespace Viandas.Domain.Core.AggregatesModel.OrderAggregate
{
    public interface IOrderRepository
    {
        Order GetOrderById(string orderId);
        Order InsertOrder(Order order);
        Order UpdateOrder(Order order);
        IEnumerable<Order> GetUserOrders(string userID, DateTime firstDate, DateTime lastDate);
    }
}
