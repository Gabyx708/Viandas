namespace Viandas.Transversal.Mapper
{
    public class Result<T> where T : class
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public Exception? Exception { get; set; }
        public string Message { get; private set; }

        public Result(T data, int statusCode, Exception exception)
        {
            Data = data;
            StatusCode = statusCode;
            Exception = exception;
            Message = string.Empty;
        }

        private Result(T data, int statusCode, string message = "OK")
        {
            Data = data;
            StatusCode = statusCode;
            Message = message;
        }


        public void SetMessage(string message)
        {
            Message = message;
        }

        public static Result<T> Success(T data)
        {
            return new Result<T>(data, 200);
        }

        public static Result<T> SuccessFullyCreated(T data)
        {
            return new Result<T>(data, 201);
        }

        public static Result<T> Error(Exception ex)
        {
            return new Result<T>(null, 500, ex);
        }
    }
}
