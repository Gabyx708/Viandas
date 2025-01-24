namespace Viandas.Domain.Core.AggregatesModel.UserAggregate
{
    internal class UserID
    {
        public string Value { get; private set; }

        public UserID(string userId)
        {
            Value = userId;
        }
    }
}
