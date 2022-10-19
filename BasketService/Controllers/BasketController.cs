using Business.BasketProviders;
using Business.Model.BasketModels;
using Microsoft.AspNetCore.Mvc;

namespace BasketService.Controllers
{
    
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class BasketController : BaseController
    {

        private readonly ILogger<BasketController> _logger;
        private IBasketProvider _basketProvider;

        public BasketController(ILogger<BasketController> logger,
            IBasketProvider basketProvider)
        {
            _logger = logger;
            _basketProvider = basketProvider;
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> Get(Guid userId)
        {
            var basket = await _basketProvider.GetOrCreateAsync(userId);
            return Ok(basket);
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> Create([FromBody] BasketRequestDto requestDto)
        {
            var basket = await _basketProvider.AddProductAsync(requestDto);
            return Ok(basket);
        }

        [HttpDelete]
        [Route("RemoveProduct")]
        public async Task<IActionResult> Delete([FromBody] BasketRequestDto requestDto)
        {
            var basket = await _basketProvider.RemoveProductAsync(requestDto);
            return Ok(basket);
        }
    }
}