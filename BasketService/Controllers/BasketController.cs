using Business.Basket;
using Business.Model.BasketModels;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

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

        [HttpGet(Name = "Basket/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var objId = ObjectId.Parse(id);
            var basket = await _basketProvider.GetAsync(objId);
            return Ok(basket);
        }

        [HttpPost(Name = "Basket")]
        public async Task<IActionResult> Create([FromBody] BasketRequestDto requestDto)
        {
            var basket = await _basketProvider.AddAsync(requestDto);
            return Ok(basket);
        }
    }
}