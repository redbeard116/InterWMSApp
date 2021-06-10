using InterWMSApp.Models;
using InterWMSApp.Services.ContractService;
using InterWMSApp.Services.StorageAreaService;
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
    public class StorageAreasController : ControllerBase
    {
        #region Fields
        private readonly ILogger<StorageAreasController> _logger;
        private readonly IStorageAreaService _storageAreaService;
        #endregion

        #region Constructor
        public StorageAreasController(ILogger<StorageAreasController> logger,
                                      IStorageAreaService storageAreaService)
        {
            _logger = logger;
            _storageAreaService = storageAreaService;
        }
        #endregion

        #region Actions
        [HttpGet]
        public async Task<IActionResult> GetStorageAreas()
        {
            try
            {
                _logger.LogInformation("get api/StorageAreas");

                var contracts = _storageAreaService.GetStorageAreas();

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
        public async Task<IActionResult> GetStorageArea(int id)
        {
            try
            {
                _logger.LogInformation($"get api/StorageAreas/{id}");

                var result = await _storageAreaService.GetStorageArea(id);
                return Ok(JsonConvert.SerializeObject(result));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddStorageArea([FromBody] StorageArea storageArea)
        {
            try
            {
                _logger.LogInformation($"add api/StorageAreas");

                var result = await _storageAreaService.AddStorageArea(storageArea);
                return Ok(JsonConvert.SerializeObject(result));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStorageArea(int id)
        {
            try
            {
                _logger.LogInformation($"delete api/StorageAreas/{id}");

                var result = await _storageAreaService.DeleteStorageArea(id);
                return Ok(JsonConvert.SerializeObject(result));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> EditStorageArea(int id, [FromBody] StorageArea storageArea)
        {
            try
            {
                _logger.LogInformation($"put api/StorageAreas/{id}");

                var result = await _storageAreaService.EditStorageArea(storageArea);
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
