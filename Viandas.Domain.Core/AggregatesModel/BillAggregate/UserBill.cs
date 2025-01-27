using Viandas.Domain.Core.AggregatesModel.OrderAggregate;

namespace Viandas.Domain.Core.AggregatesModel.BillAggregate
{
    public class UserBill
    {
        public string UserId { get; private set; }
        public decimal Total { get; private set; }
        public decimal Subtotal { get; private set; }
        public decimal Discount { get; private set; }
        public decimal ToPay { get; private set; }
        public int TotalOrders { get; private set; }
        public int CancelledOrders { get; private set; }
        public int ConfirmedOrders { get; private set; }

        public UserBill(string userId, List<Order> orders)
        {
            UserId = userId;
            Total = CalculateTotalAmount(orders);
            Subtotal = CalculateSubTotal(orders);
            Discount = CalculateDiscount(orders);
            ToPay = CalculateTotalToPay(orders);

            TotalOrders = orders.Count;
            ConfirmedOrders = TotalConfirmedOrders(orders);
            CancelledOrders = TotalCancelledOrders(orders);
        }

        private decimal CalculateTotalAmount(List<Order> orders)
        {
            return orders.Sum(o => o.GetTotalAmount());
        }

        public decimal CalculateSubTotal(List<Order> orders)
        {
            return orders.Where(o => o.Status == Order.OrderStatus.CONFIRMED)
                          .Sum(o => o.GetTotalAmount());
        }

        private decimal CalculateDiscount(List<Order> orders)
        {
            return orders.Where(o => o.Status == Order.OrderStatus.CONFIRMED).
                          Sum(o => o.GetDiscountAmount());
        }

        private decimal CalculateTotalToPay(List<Order> orders)
        {
            return orders.Sum(O => O.GetTotalToPay());
        }

        private int TotalConfirmedOrders(List<Order> orders)
        {
            return orders.Count(o => o.Status == Order.OrderStatus.CONFIRMED);
        }

        private int TotalCancelledOrders(List<Order> orders)
        {
            return orders.Count(o => o.Status == Order.OrderStatus.CANCELLED);
        }


    }
}
