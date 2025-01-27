namespace Viandas.Domain.Core.AggregatesModel.OrderAggregate
{
    internal class OrderID
    {
        public string Value { get; private set; }

        public OrderID(string userId)
        {
            DateTime now = DateTime.Now;
            Value = $"OR_{userId}_{now.ToString("yyyymmddssHH")}";
        }
    }
}
