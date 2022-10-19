using Business.Model.BasketModels;
using Core.Exceptions;
using DataLayer.Repositories;
using Elasticsearch.Net;
using Integration.ProductServices;
using Model.BasketModels;

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

        public async Task<BasketResponseDto> GetOrCreateAsync(Guid userId)
        {
            Basket basket = await GetBasketAsync(userId);
            if (string.IsNullOrWhiteSpace(basket.UserId))
            {
                basket.UserId = userId.ToString();
                await _basketRepository.AddAsync(basket);
            }
            basket.CalculatePayment();
            return new BasketResponseDto().ConvertFromBasket(basket);
        }

        public async Task<BasketResponseDto> AddProductAsync(BasketRequestDto requestDto)
        {
            Basket basket = await GetBasketAsync(requestDto.UserId);

            var product = await _productService.GetProductByIdAsync(requestDto.ProductId);
            if (product == null) throw new ProductException(BusinessBaseExceptionKeys.ProductNotFoundException, "Ürün bulunamadı");

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
                var newQuantity = basketProduct.Quantity + requestDto.Quantity;
                if (product.Stock < newQuantity) throw new ProductStockNotSufficientException();
                basketProduct.Quantity = newQuantity;
            }


            basket.CalculatePayment();
            if (string.IsNullOrWhiteSpace(basket.UserId))
            {
                basket.UserId = requestDto.UserId.ToString();
                await _basketRepository.AddAsync(basket);
            }
            else
                _ = await _basketRepository.UpdateAsync(basket);
            
            return new BasketResponseDto().ConvertFromBasket(basket);
        }

        public async Task<BasketResponseDto> RemoveProductAsync(BasketRequestDto requestDto)
        {
            Basket basket = await GetBasketAsync(requestDto.UserId);

            if (string.IsNullOrWhiteSpace(basket.UserId)) throw new BasketNotFoundException();

            var basketProduct = basket.BasketItems.FirstOrDefault(x => x.ProductId == requestDto.ProductId.ToString());
            if (basketProduct == null) throw new BasketItemNotFoundException();

            if (basketProduct.Quantity < requestDto.Quantity)
                throw new BasketException(BusinessBaseExceptionKeys.BasketItemQuantityCouldNotBeLessException, "Düşülecek Ürün sayısı daha az olamaz");
            else if (basketProduct.Quantity == requestDto.Quantity)
                basket.BasketItems.Remove(basketProduct);
            else
                basketProduct.Quantity -= requestDto.Quantity;

            basket.CalculatePayment();
            await _basketRepository.UpdateAsync(basket);
            return new BasketResponseDto().ConvertFromBasket(basket);
        }

        private async Task<Basket> GetBasketAsync(Guid userId)
        {
            var basket = await _basketRepository.FirstOrDefaultAsync(x => x.UserId == userId.ToString());
            basket ??= new Basket();
            return basket;
        }
    }
}
