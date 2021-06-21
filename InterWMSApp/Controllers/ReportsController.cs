using InterWMSApp.Services.ReportsService;
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
    public class ReportsController : ControllerBase
    {
        #region Fields
        private readonly ILogger<ReportsController> _logger;
        private readonly IReportsService _reportsService;
        #endregion

        #region Constructor
        public ReportsController(ILogger<ReportsController> logger,
                                 IReportsService reportsService)
        {
            _logger = logger;
            _reportsService = reportsService;
        }
        #endregion

        #region Acts
        [HttpGet("sales")]
        public async Task<IActionResult> GetSalesProductsReport(long startTime, long endTime)
        {
            try
            {
                _logger.LogDebug($"Get api/reports/sales?startTime={startTime}&endTime={endTime}");

                var result = await _reportsService.GetProductsReport(Models.OperationType.Shipping, startTime, endTime);

                return Ok(JsonConvert.SerializeObject(result));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("purchase")]
        public async Task<IActionResult> GetPurchaseProductsReport(long startTime, long endTime)
        {
            try
            {
                _logger.LogDebug($"Get api/reports/sales?startTime={startTime}&endTime={endTime}");

                var result = await _reportsService.GetProductsReport(Models.OperationType.Reception, startTime, endTime);

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
