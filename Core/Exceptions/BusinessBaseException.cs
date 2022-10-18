namespace Core.Exceptions
{
    public class BusinessBaseException : Exception
    {
        public int ExceptionKey { get; set; }
        public int StatusCode { get; set; }
        public BusinessBaseException(int exceptionKey, string message) : base(message)
        {
            this.ExceptionKey = exceptionKey;
        }

        public BusinessBaseException(int exceptionKey, string message, int statusCode) : base(message)
        {
            this.ExceptionKey = exceptionKey;
            this.StatusCode = statusCode;
        }

        public BusinessBaseException(string message) : base(message)
        {
            this.ExceptionKey = BusinessBaseExceptionKeys.UnhandledBusinessException;
        }
    }
}
