using Business.Model.BasketModels;
using MongoDB.Bson;

namespace Business.Basket
{
    public interface IBasketProvider
    {
        Task<BasketResponseDto> GetAsync(ObjectId basketId);
        Task<BasketResponseDto> AddAsync(BasketRequestDto requestDto);
        Task<BasketResponseDto> UpdateAsync(BasketRequestDto requestDto);
        Task<BasketResponseDto> DeleteAsync(ObjectId basketId);
    }
}