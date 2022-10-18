using Business.Model.BasketModels;
using MongoDB.Bson;

namespace Business.BasketProviders
{
    public interface IBasketProvider
    {
        Task<BasketResponseDto> GetAsync(ObjectId basketId);
        Task<BasketResponseDto> AddProductAsync(BasketRequestDto requestDto);
        Task<BasketResponseDto> RemoveProductAsync(BasketRequestDto requestDto);
    }
}