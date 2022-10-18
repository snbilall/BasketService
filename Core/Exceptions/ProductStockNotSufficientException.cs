namespace Core.Exceptions
{
    public class ProductStockNotSufficientException : BusinessBaseException
    {
        public ProductStockNotSufficientException() : 
            base(BusinessBaseExceptionKeys.ProductStockNotSufficientException, "Ürün stoğu yetersiz")
        {
        }
    }
}
