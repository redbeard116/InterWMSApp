using InterWMSApp.Models;
using InterWMSApp.Services.ProductStorageService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace InterWMSApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductStoragesController : ControllerBase
    {
        #region Fields
        private readonly ILogger<ProductStoragesController> _logger;
        private readonly IProductStorageService _productStorageService;
        #endregion

        #region Constructor
        public ProductStoragesController(ILogger<ProductStoragesController> logger,
                                         IProductStorageService productStorageService)
        {
            _logger = logger;
            _productStorageService = productStorageService;
        }
        #endregion

        #region Actions
        [HttpGet]
        public async Task<IActionResult> GetProductStorages()
        {
            try
            {
                _logger.LogInformation("get api/ProductStorages");

                var contracts = _productStorageService.GetProductStorages();

                return Ok(JsonConvert.SerializeObject(contracts));
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
        public async Task<IActionResult> GetProductStorage(int id)
        {
            try
            {
                _logger.LogInformation($"get api/ProductStorages/{id}");

                var result = await _productStorageService.GetProductStorage(id);
                return Ok(JsonConvert.SerializeObject(result));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProductStorage([FromBody] ProductStorage productStorage)
        {
            try
            {
                _logger.LogInformation($"add api/ProductStorages");

                var result = await _productStorageService.AddProductStorage(productStorage);
                return Ok(JsonConvert.SerializeObject(result));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductStorage(int id)
        {
            try
            {
                _logger.LogInformation($"delete api/ProductStorages/{id}");

                var result = await _productStorageService.DeleteProductStorage(id);
                return Ok(JsonConvert.SerializeObject(result));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("edit")]
        public async Task<IActionResult> EditProductStorage([FromBody] ProductStorage productStorage)
        {
            try
            {
                _logger.LogInformation($"put api/ProductStorages/{productStorage.Id}");

                var result = await _productStorageService.EditProductStorage(productStorage);
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
