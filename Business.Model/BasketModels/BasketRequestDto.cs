using Model.BasketModels;

namespace Business.Model.BasketModels
{
    public class BasketRequestDto
    {
        public Guid UserId { get; set; }
        public List<BasketItemDto>? BasketItems { get; set; }

        public Basket ConvertToBasket()
        {
            var basket = new Basket();
            basket.UserId = UserId.ToString();
            if (BasketItems != null)
            {
                basket.BasketItems = BasketItems.ConvertAll(x => new BasketItem
                {
                    ProductId = x.ProductId.ToString(),
                    Quantity = x.Quantity
                });
            }
            else
            {
                basket.BasketItems = new List<BasketItem>();
            }
            return basket;
        }
    }
}
