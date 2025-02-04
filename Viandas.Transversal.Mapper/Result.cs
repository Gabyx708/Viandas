namespace Viandas.Transversal.Mapper
{
    public class Result<T> where T : class
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public Exception Exception { get; set; }
        public string Message { get; private set; }

        public Result(T data, int statusCode, Exception exception)
        {
            Data = data;
            StatusCode = statusCode;
            Exception = exception;
            Message = string.Empty;
        }

        public void SetMessage(string message)
        { 
            Message = message;
        }
    }
}
