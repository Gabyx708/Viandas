namespace Viandas.Domain.Core.AggregatesModel.UserAggregate
{
    internal class UserPassword
    {
        public string Value { get; private set; }

        public UserPassword(string password) 
        {
            //Value = password;
            Value = "super secreto";
        }
    }
}
