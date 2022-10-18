namespace Core.Exceptions
{
    public class ProductException : BusinessBaseException
    {
        public ProductException(int exceptionKey, string message) : base(exceptionKey, message)
        {
            StatusCode = 450;
        }

        public ProductException(int exceptionKey, string message, int statusCode) : base(exceptionKey, message, statusCode)
        {
        }
    }
}
