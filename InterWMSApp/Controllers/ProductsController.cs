using InterWMSApp.Models;
using InterWMSApp.Services.ProductService;
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
    public class ProductsController : ControllerBase
    {
        #region Fields
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productServices;
        #endregion

        #region Constructor
        public ProductsController(ILogger<ProductsController> logger,
                                  IProductService productServices)
        {
            _logger = logger;
            _productServices = productServices;
        }
        #endregion

        #region Actions
        /// <summary>
        /// Получение всех продустов
        /// </summary>
        /// <returns>Возвращает все продукты</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            _logger.LogInformation("get api/products");

            var products = _productServices.GetProducts();
            if (products != null)
            {
                return Ok(JsonConvert.SerializeObject(products));
            }
            return BadRequest("Ошибка при получении задании");
        }

        /// <summary>
        /// Возвращает конкретный продукт
        /// </summary>
        /// <param name="id">Id продукта</param>
        /// <returns>Найденный продукт</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            _logger.LogInformation($"get api/products/{id}");

            var product = await _productServices.GetProduct(id);
            if (product != null)
            {
                return Ok(JsonConvert.SerializeObject(product));
            }
            return BadRequest("Ошибка при получении задания");
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            _logger.LogInformation($"add api/products");

            int? id = await _productServices.AddProduct(product);
            if (id.HasValue)
            {
                product.Id = id.Value;
                return Ok(JsonConvert.SerializeObject(product));
            }
            return BadRequest("Ошибка при создании задания");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            _logger.LogInformation($"delete api/products/{id}");

            var result = await _productServices.DeleteProduct(id);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Ошибка при удалении задания");
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> EditProduct(int id, [FromBody] Product product)
        {
            _logger.LogInformation($"EditProduct {id}");

            var result = await _productServices.EditProduct(product);
            if (result != null)
            {
                return Ok(JsonConvert.SerializeObject(result));
            }
            return BadRequest("Ошибка при изменении задания");
        }
        #endregion
    }
}
