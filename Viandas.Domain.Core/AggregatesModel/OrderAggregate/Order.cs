namespace Viandas.Domain.Core.AggregatesModel.OrderAggregate
{
    public class Order
    {
        public string OrderID { get; private set; }
        public string UserID { get; private set; }
        public string DiscountID { get; private set; }
        public OrderStatus Status { get; private set; }
        public DateTime CreationDate { get; private set; }

        private readonly Discount _discount;
        public List<OrderItem> Items { get; private set; }
        public List<OrderTransition> Transitions { get; private set; }

        private readonly OrderID _orderID;
        public enum OrderStatus
        {
            CONFIRMED,
            CANCELLED
        }

        public Order(string userId, Discount discount)
        {
            _orderID = new OrderID(userId);
            OrderID = _orderID.Value;
            UserID = userId;
            _discount = discount;

            DiscountID = discount.Id;
            Status = OrderStatus.CONFIRMED;

            Items = new List<OrderItem>();
            Transitions = new List<OrderTransition>();
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public decimal GetTotalAmount()
        {
            return Items.Sum(item => item.GetTotalPrice());
        }

        public decimal GetTotalToPay()
        {
            decimal totalAmount = GetTotalAmount();
            decimal discountFactor = 1 - (_discount.GetAmount() / 100);
            return totalAmount * discountFactor;
        }

        public decimal GetDiscountAmount()
        {
            decimal totalAmount = GetTotalAmount();
            decimal discountPercentage = _discount.GetAmount();
            return (totalAmount * discountPercentage) / 100;
        }

        public void AddTransition(OrderTransition transition)
        {
            Status = transition.GetToStatus();
            Transitions.Add(transition);
        }




    }
}
