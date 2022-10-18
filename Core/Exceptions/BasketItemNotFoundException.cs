namespace Core.Exceptions
{
    public class BasketNotFoundException : BasketException
    {
        public BasketNotFoundException() : 
            base(BusinessBaseExceptionKeys.BasketNotFoundException, "Sepet bulunamadı")
        {
        }
    }
}
