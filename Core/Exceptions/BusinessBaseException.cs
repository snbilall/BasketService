namespace Core.Exceptions
{
    internal class BusinessBaseException : Exception
    {
        public int exceptionKey { get; set; }
        public BusinessBaseException(int exceptionKey, string message) : base(message)
        {
            this.exceptionKey = exceptionKey;
        }

        public BusinessBaseException(string message) : base(message)
        {
            this.exceptionKey = BusinessBaseExceptionKeys.UnhandledBusinessException;
        }
    }
}
