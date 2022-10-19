using Model.BasketModels;

namespace Business.Model.BasketModels
{
    public class BasketRequestDto : BasketItemDto
    {
        public Guid UserId { get; set; }
    }
}
