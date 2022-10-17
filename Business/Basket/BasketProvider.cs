using Business.Model.BasketModels;
using DataLayer.Repositories;
using MongoDB.Bson;

namespace Business.Basket
{
    public class BasketProvider : IBasketProvider
    {
        private IBasketRepository _basketRepository;

        public BasketProvider(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task<BasketResponseDto> AddAsync(BasketRequestDto requestDto)
        {
            var basket = requestDto.ConvertToBasket();
            await _basketRepository.AddAsync(basket);
            return new BasketResponseDto().ConvertFromBasket(basket);
        }

        public async Task<BasketResponseDto> DeleteAsync(ObjectId basketId)
        {
            var respose = await _basketRepository.DeleteAsync(basketId);
            return new BasketResponseDto().ConvertFromBasket(respose);
        }

        public async Task<BasketResponseDto> GetAsync(ObjectId basketId)
        {
            var basket = await _basketRepository.GetByIdAsync(basketId);
            return new BasketResponseDto().ConvertFromBasket(basket);
        }

        public async Task<BasketResponseDto> UpdateAsync(BasketRequestDto requestDto)
        {
            var basket = requestDto.ConvertToBasket();
            await _basketRepository.UpdateAsync(basket);
            return new BasketResponseDto().ConvertFromBasket(basket);
        }
    }
}
