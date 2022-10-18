namespace Core.Exceptions
{
    public static class BusinessBaseExceptionKeys
    {
        public static readonly int UnhandledBusinessException = 10;
        
        public static readonly int ProductNotFoundException = 50;
        public static readonly int ProductStockNotSufficientException = 51;
        
        public static readonly int BasketNotFoundException = 100;
        public static readonly int BasketItemNotFoundException = 101;
        public static readonly int BasketItemQuantityCouldNotBeLessException = 102;
    }
}
