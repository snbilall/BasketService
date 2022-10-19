using Business.Model.BasketModels;

namespace Business.BasketProviders
{
    public interface IBasketProvider
    {
        Task<BasketResponseDto> GetOrCreateAsync(Guid userId);
        Task<BasketResponseDto> AddProductAsync(BasketRequestDto requestDto);
        Task<BasketResponseDto> RemoveProductAsync(BasketRequestDto requestDto);
    }
}