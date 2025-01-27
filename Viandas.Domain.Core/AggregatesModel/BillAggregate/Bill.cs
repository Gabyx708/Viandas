using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viandas.Domain.Core.AggregatesModel.OrderAggregate;

namespace Viandas.Domain.Core.AggregatesModel.BillAggregate
{
    public class Bill
    {
        private int Year { get; }
        private int Month { get; }
        private DateTime _startDate;
        private DateTime _endDate;

        public decimal TotalAmount { get;}
        public decimal SubtotalAmount { get; }
        public decimal TotalDiscount { get; }
        public decimal TotalToPay { get; }
        public int TotalOrders { get; }
        public int CancelledOrders { get; }
        public int ConfirmedOrders { get; }

        private List<UserBill> UserBills { get; }
        private readonly List<Order> _orders;

        public Bill(List<Order> orders)
        {
            _orders = orders;
            UserBills = new List<UserBill>();

            TotalAmount = CalculateTotalAmount();
            SubtotalAmount = CalculateSubTotalAmount();
            TotalDiscount = CalculateTotalDiscount();
            TotalToPay = CalculateTotalToPay();
            TotalOrders = orders.Count;
            CancelledOrders = GetCancelledOrdersQuantity();
            ConfirmedOrders = GetConfirmedOrdersQuantity();

            GroupByUsers();
        }

        public decimal CalculateTotalAmount()
        {
            return _orders.Sum(o => o.GetTotalAmount());
        }

        public decimal CalculateSubTotalAmount()
        {
            return _orders.Where(o => o.Status == Order.OrderStatus.CONFIRMED)
                          .Sum(o => o.GetTotalAmount());
        }

        public decimal CalculateTotalDiscount()
        {
            return _orders.Where(o => o.Status == Order.OrderStatus.CONFIRMED)
                          .Sum(o => o.GetDiscountAmount());
        }

        public decimal CalculateTotalToPay()
        {
            return _orders.Where(o => o.Status == Order.OrderStatus.CONFIRMED)
                          .Sum(o => o.GetTotalToPay());
        }
        private int GetCancelledOrdersQuantity()
        {
            return _orders.Count(o => o.Status == Order.OrderStatus.CANCELLED);
        }

        private int GetConfirmedOrdersQuantity()
        {
            return _orders.Count(o => o.Status == Order.OrderStatus.CONFIRMED);
        }

        private void GroupByUsers()
        {
            var orderByUser = _orders.GroupBy(o => o.UserID);

            foreach (var group in orderByUser)
            {
                string userId = group.Key;
                List<Order> userOrders = group.ToList();

                UserBills.Add(new UserBill(userId,userOrders));
            }
        }
    }
}
