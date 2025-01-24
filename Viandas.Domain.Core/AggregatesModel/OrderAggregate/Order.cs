using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viandas.Domain.Core.AggregatesModel.OrderAggregate
{
    public class Order
    {
        public string OrderID { get; private set; }
        public string UserID { get; private set; }
        public string DiscountID { get;private set; }
        public OrderStatus Status { get; private set; }

        private readonly Discount _discount;
        public List<OrderItem> Items { get; private set; }
        public List<OrderTransition> Transitions { get; private set; }
        public enum OrderStatus
        {
            CONFIRMED,
            CANCELLED
        }

        public Order(string userId,Discount discount)
        {
            OrderID = $"{DateTime.Now}"; //TODO: corregir ,extraer a un metodo
            UserID = userId;
            _discount = discount;

            DiscountID = _discount.DiscountID;
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

        public void AddTransition(OrderTransition transition)
        {
            Status = transition.GetToStatus();
            Transitions.Add(transition);
        }


    }
}
