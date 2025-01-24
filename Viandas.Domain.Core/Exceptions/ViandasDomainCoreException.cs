namespace Viandas.Domain.Core.Exceptions
{
    internal class ViandasDomainCoreException : Exception
    {
        public ViandasDomainCoreException()
        { }

        public ViandasDomainCoreException(string message)
            : base(message)
        { }

        public ViandasDomainCoreException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public string GetMessage()
        {
            return this.Message;
        }
    }
}
