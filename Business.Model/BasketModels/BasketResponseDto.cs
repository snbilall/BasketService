using Model.BasketModels;
using MongoDB.Bson;

namespace Business.Model.BasketModels
{
    public class BasketResponseDto
    {
        public string BasketId { get; set; }
        public Guid UserId { get; set; }
        public List<BasketItemResponseDto>? BasketItems { get; set; }

        public BasketResponseDto ConvertFromBasket(Basket basket)
        {
            BasketId = basket.Id.ToString();
            UserId = Guid.Parse(basket.UserId);
            if (basket.BasketItems != null)
            {
                BasketItems = basket.BasketItems.ConvertAll(x => new BasketItemResponseDto
                {
                    ProductId = Guid.Parse(x.ProductId),
                    Quantity = x.Quantity,
                    Price = x.Price
                });
            }
            else
            {
                BasketItems = new List<BasketItemResponseDto>();
            }
            return this;
        }
    }

    public class BasketItemResponseDto : BasketItemDto
    {
        public decimal Price { get; set; }
    }
}
