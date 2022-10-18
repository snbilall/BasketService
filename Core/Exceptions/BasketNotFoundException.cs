namespace Core.Exceptions
{
    public class BasketItemNotFoundException : BasketException
    {
        public BasketItemNotFoundException() : 
            base(BusinessBaseExceptionKeys.BasketItemNotFoundException, "Ürün sepette bulunamadı")
        {
        }
    }
}
