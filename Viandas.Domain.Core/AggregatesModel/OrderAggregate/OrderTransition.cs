using Viandas.Domain.Core.Exceptions;

namespace Viandas.Domain.Core.AggregatesModel.OrderAggregate
{
    public class OrderTransition
    {
        public string OrderID { get; private set; }
        public string UserID { get; private set; }
        public Order.OrderStatus FromStatus { get; private set; }
        public Order.OrderStatus ToStatus { get; private set; }
        public string? Note { get; private set; }
        public DateTime TransitionDate { get; private set; }

        public OrderTransition(string orderId, string userId, Order.OrderStatus from, Order.OrderStatus to)
        {
            if (from == Order.OrderStatus.CANCELLED)
            {
                throw new ViandasDomainCoreException("it is not possible to modify a cancelled order");
            }

            FromStatus = from;
            ToStatus = to;
            OrderID = orderId;
            UserID = userId;
            TransitionDate = DateTime.Now;
        }

        public void AddNote(string note)
        {
            this.Note = note;
        }

        public string GetNote()
        {
            return this.Note ?? " ";
        }

        public Order.OrderStatus GetToStatus()
        {
            return ToStatus;
        }
    }
}
