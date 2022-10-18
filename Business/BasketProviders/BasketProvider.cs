using Business.Model.BasketModels;
using Core.Exceptions;
using DataLayer.Repositories;
using Integration.ProductServices;
using Model.BasketModels;
using MongoDB.Bson;

namespace Business.BasketProviders
{
    public class BasketProvider : IBasketProvider
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IProductService _productService;

        public BasketProvider(IBasketRepository basketRepository,
            IProductService productService)
        {
            _basketRepository = basketRepository;
            _productService = productService;
        }

        public async Task<BasketResponseDto> GetAsync(ObjectId basketId)
        {
            var basket = await _basketRepository.GetByIdAsync(basketId);
            return new BasketResponseDto().ConvertFromBasket(basket);
        }

        public async Task<BasketResponseDto> AddProductAsync(BasketRequestDto requestDto)
        {
            //await _productService.CreateDummyProductsAsync();

            Basket basket = await GetBasketAsync(requestDto.BasketId);

            var product = await _productService.GetProductByIdAsync(requestDto.ProductId);
            if (product == null)
            {
                throw new ProductException(BusinessBaseExceptionKeys.ProductNotFoundException, "Ürün bulunamadı");
            }

            var basketProduct = basket.BasketItems.FirstOrDefault(x => x.ProductId == product.Id.ToString());
            if (basketProduct == null)
            {
                if (product.Stock < requestDto.Quantity) throw new ProductStockNotSufficientException();
                basket.BasketItems.Add(new BasketItem
                {
                    ProductId = product.Id.ToString(),
                    Quantity = requestDto.Quantity,
                    Price = product.Price
                });
            }
            else
            {
                if (product.Stock < basketProduct.Quantity + requestDto.Quantity) throw new ProductStockNotSufficientException();
                basketProduct.Quantity += basketProduct.Quantity;
            }

    
            if (string.IsNullOrWhiteSpace(basket.UserId))
            {
                basket.UserId = requestDto.UserId.ToString();
                await _basketRepository.AddAsync(basket);
            }
            else
            {
                await _basketRepository.UpdateAsync(basket);
            }
            
            return new BasketResponseDto().ConvertFromBasket(basket);
        }

        public async Task<BasketResponseDto> RemoveProductAsync(BasketRequestDto requestDto)
        {
            Basket basket = await GetBasketAsync(requestDto.BasketId);
            var basketProduct = basket.BasketItems.FirstOrDefault(x => x.ProductId == requestDto.ProductId.ToString());
            
            if (basketProduct == null) throw new BasketItemNotFoundException();

            if (basketProduct.Quantity < requestDto.Quantity)
            {
                throw new BasketException(BusinessBaseExceptionKeys.BasketItemQuantityCouldNotBeLessException, "Düşülecek Ürün sayısı daha az olamaz");
            }
            else if (basketProduct.Quantity < requestDto.Quantity)
            {
                basket.BasketItems.Remove(basketProduct);
            }
            else
            {
                basketProduct.Quantity -= requestDto.Quantity;
            }
            
            await _basketRepository.UpdateAsync(basket);
            return new BasketResponseDto().ConvertFromBasket(basket);
        }

        private async Task<Basket> GetBasketAsync(string basketId)
        {
            if (string.IsNullOrWhiteSpace(basketId))
            {
                return new Basket();
            }
            else
            {
                var basket = await _basketRepository.GetByIdAsync(ObjectId.Parse(basketId));
                if (basket == null) throw new BasketNotFoundException();
                return basket;
            }
        }
    }
}
