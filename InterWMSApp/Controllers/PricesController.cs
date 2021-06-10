using System.Threading.Tasks;
using InterWMSApp.Models;
using InterWMSApp.Services.ProductPriceService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace InterWMSApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {
        #region Fields
        private readonly ILogger<PricesController> _logger;
        private readonly IProductPriceService _productPriceService;
        #endregion

        #region Constructor
        public PricesController(ILogger<PricesController> logger,
                                IProductPriceService productPriceService)
        {
            _logger = logger;
            _productPriceService = productPriceService;
        }
        #endregion

        #region Actions
        [HttpGet]
        public IActionResult GetProductPrices()
        {
            try
            {
                _logger.LogInformation("get api/Prices");

                var result = _productPriceService.GetProductPrices();

                return Ok(JsonConvert.SerializeObject(result));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Возвращает конкретный продукт
        /// </summary>
        /// <param name="id">Id продукта</param>
        /// <returns>Найденный продукт</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductPrice(int id)
        {
            try
            {
                _logger.LogInformation($"get api/Prices/{id}");

                var result = await _productPriceService.GetProductPrice(id);
                return Ok(JsonConvert.SerializeObject(result));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProductPrice([FromBody] ProductPrice price)
        {
            try
            {
                _logger.LogInformation($"add api/Prices");

                var result = await _productPriceService.AddProductPrice(price);
                return Ok(JsonConvert.SerializeObject(result));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductPrice(int id)
        {
            try
            {
                _logger.LogInformation($"delete api/Prices/{id}");

                var result = await _productPriceService.DeleteProductPrice(id);
                return Ok(JsonConvert.SerializeObject(result));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> EditProductPrice(int id, [FromBody] ProductPrice price)
        {
            try
            {
                _logger.LogInformation($"put api/Prices/{id}");

                var result = await _productPriceService.EditProductPrice(price);
                return Ok(JsonConvert.SerializeObject(result));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
