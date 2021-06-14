using InterWMSApp.Extensions;
using InterWMSApp.Models;
using InterWMSApp.Services.ContractService;
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
    public class ContractsController : ControllerBase
    {
        #region Fields
        private readonly ILogger<ContractsController> _logger;
        private readonly IContractService _contractService;
        #endregion

        #region Constructor
        public ContractsController(ILogger<ContractsController> logger,
                                   IContractService contractService)
        {
            _logger = logger;
            _contractService = contractService;
        }
        #endregion

        #region Actions
        [HttpGet]
        public async Task<IActionResult> GetContracts()
        {
            try
            {
                _logger.LogInformation("get api/Contracts");

                var contracts = _contractService.GetContracts();

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
        public async Task<IActionResult> GetContract(int id)
        {
            try
            {
                _logger.LogInformation($"get api/Contracts/{id}");

                var result = await _contractService.GetContract(id);
                return Ok(JsonConvert.SerializeObject(result));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddContract()
        {
            try
            {
                _logger.LogInformation($"add api/Contracts");
                var body = await this.GetStringFromBody();
                var result = await _contractService.AddContract(JsonConvert.DeserializeObject<ContractApiM>(body));
                return Ok(JsonConvert.SerializeObject(result));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContract(int id)
        {
            try
            {
                _logger.LogInformation($"delete api/Contracts/{id}");

                var result = await _contractService.DeleteContract(id);
                return Ok(JsonConvert.SerializeObject(result));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> EditContract(int id)
        {
            try
            {
                _logger.LogInformation($"put api/Contracts/{id}");
                var body = await this.GetStringFromBody();
                var result = await _contractService.EditContract(JsonConvert.DeserializeObject<ContractApiM>(body));
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
