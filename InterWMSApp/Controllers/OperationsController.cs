using InterWMSApp.Models;
using InterWMSApp.Services.OperationService;
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
    public class OperationsController : ControllerBase
    {
        #region Fields
        private readonly ILogger<OperationsController> _logger;
        private readonly IOperationService _operationService;
        #endregion

        #region Constructor
        public OperationsController(ILogger<OperationsController> logger,
                                    IOperationService operationService)
        {
            _logger = logger;
            _operationService = operationService;
        }
        #endregion

        #region Actions
        [HttpGet]
        public async Task<IActionResult> GetOperations()
        {
            try
            {
                _logger.LogInformation("get api/Operations");

                var contracts = _operationService.GetOperations();

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
        public async Task<IActionResult> GetOperation(int id)
        {
            try
            {
                _logger.LogInformation($"get api/Operations/{id}");

                var result = await _operationService.GetOperation(id);
                return Ok(JsonConvert.SerializeObject(result));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOperation([FromBody] Operation operation)
        {
            try
            {
                _logger.LogInformation($"add api/Operations");

                var result = await _operationService.AddOperation(operation);
                return Ok(JsonConvert.SerializeObject(result));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperation(int id)
        {
            try
            {
                _logger.LogInformation($"delete api/Operations/{id}");

                var result = await _operationService.DeleteOperation(id);
                return Ok(JsonConvert.SerializeObject(result));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> EditOperation(int id, [FromBody] Operation operation)
        {
            try
            {
                _logger.LogInformation($"put api/Operations/{id}");

                var result = await _operationService.EditOperation(operation);
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