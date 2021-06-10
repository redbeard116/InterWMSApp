using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InterWMSApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReportsController : ControllerBase
    {
        #region Fields
        private readonly ILogger<ReportsController> _logger;
        #endregion

        #region Constructor
        public ReportsController(ILogger<ReportsController> logger)
        {
            _logger = logger;
        }
        #endregion
    }
}
