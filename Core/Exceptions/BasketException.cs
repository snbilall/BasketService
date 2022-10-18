namespace Core.Exceptions
{
    public class BasketException : BusinessBaseException
    {
        public BasketException(int exceptionKey, string message) : base(exceptionKey, message)
        {
            StatusCode = 450;
        }

        public BasketException(int exceptionKey, string message, int statusCode) : base(exceptionKey, message, statusCode)
        {
        }
    }
}
