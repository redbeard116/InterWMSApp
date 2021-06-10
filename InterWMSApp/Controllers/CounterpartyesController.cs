using InterWMSApp.Extensions;
using InterWMSApp.Models;
using InterWMSApp.Services.CounterpartyService;
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
    public class CounterpartyesController : ControllerBase
    {
        #region Fields
        private readonly ILogger<CounterpartyesController> _logger;
        private readonly ICounterpartyService _counterpartyService;
        #endregion

        #region Constructor
        public CounterpartyesController(ILogger<CounterpartyesController> logger,
                                        ICounterpartyService counterpartyService)
        {
            _logger = logger;
            _counterpartyService = counterpartyService;
        }
        #endregion

        #region Actions
        [HttpGet]
        public async Task<IActionResult> GetCounterpartyes()
        {
            try
            {
                _logger.LogInformation("get api/Counterpartyes");

                var contracts = _counterpartyService.GetCounterpartyes();

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
        public async Task<IActionResult> GetCounterparty(int id)
        {
            try
            {
                _logger.LogInformation($"get api/Counterpartyes/{id}");

                var result = await _counterpartyService.GetCounterparty(id);
                return Ok(JsonConvert.SerializeObject(result));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCounterparty()
        {
            try
            {
                _logger.LogInformation($"add api/Counterpartyes");
                var body = await this.GetStringFromBody();
                var result = await _counterpartyService.AddCounterparty(JsonConvert.DeserializeObject<Counterparty>(body));
                return Ok(JsonConvert.SerializeObject(result));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCounterparty(int id)
        {
            try
            {
                _logger.LogInformation($"delete api/Counterpartyes/{id}");

                var result = await _counterpartyService.DeleteCounterparty(id);
                return Ok(JsonConvert.SerializeObject(result));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> EditCounterparty(int id, [FromBody] Counterparty counterparty)
        {
            try
            {
                _logger.LogInformation($"put api/Counterpartyes/{id}");

                var result = await _counterpartyService.EditCounterparty(counterparty);
                    return Ok(result.ToJson());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
