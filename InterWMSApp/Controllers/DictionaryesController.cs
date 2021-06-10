using InterWMSApp.Models;
using InterWMSApp.Services.DictionaryService;
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
    public class DictionaryesController : ControllerBase
    {
        #region Fields
        private readonly ILogger<DictionaryesController> _logger;
        private readonly IDictionaryService _dictionaryService;
        #endregion

        #region Constructor
        public DictionaryesController(ILogger<DictionaryesController> logger,
                                      IDictionaryService dictionaryService)
        {
            _logger = logger;
            _dictionaryService = dictionaryService;
        }
        #endregion

        #region Actions
        // GET api/<DictionaryesController>/accessytypes
        [HttpGet("accessytypes")]
        public IActionResult GetAccessTypes()
        {
            try
            {
                _logger.LogDebug("api/dictionatryes/accessytypes");
                var types = _dictionaryService.GetAccessTypes();
                var json = JsonConvert.SerializeObject(types);
                return Ok(json);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //POST api/<DictionaryesController>/accessytypes
        [HttpPost("accessytypes")]
        [Authorize("Admin")]
        public async Task<IActionResult> AddAccessType([FromBody] AccessType accessType)
        {
            try
            {
                _logger.LogDebug("Add access type");
                accessType = await _dictionaryService.AddAccessType(accessType);
                var json = JsonConvert.SerializeObject(accessType);
                return Ok(json);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //DELETE api/<DictionaryesController>/accessytypes/:id
        [HttpDelete("accessytypes/{id}")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteAccessType(int id)
        {
            try
            {
                _logger.LogDebug("Delete access type");
                var result = await _dictionaryService.DeleteAccessType(id);
                if (result)
                {
                    return Ok();
                }

                return Problem("Not found");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // GET api/<DictionaryesController>/producttypes
        [HttpGet("producttypes")]
        public IActionResult GetProductTypes()
        {
            try
            {
                _logger.LogDebug("api/dictionatryes/producttypes");
                var types = _dictionaryService.GetProductTypes();
                var json = JsonConvert.SerializeObject(types);
                return Ok(json);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //POST api/<DictionaryesController>/accessytypes
        [HttpPost("producttypes")]
        [Authorize("Admin")]
        public async Task<IActionResult> AddProductTypes([FromBody] ProductType productType)
        {
            try
            {
                _logger.LogDebug("Add product type");
                productType = await _dictionaryService.AddProductTypes(productType);
                var json = JsonConvert.SerializeObject(productType);
                return Ok(json);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //DELETE api/<DictionaryesController>/accessytypes/:id
        [HttpDelete("producttypes/{id}")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteProductTypes(int id)
        {
            try
            {
                _logger.LogDebug("Delete product type");
                var result = await _dictionaryService.DeleteProductTypes(id);
                if (result)
                {
                    return Ok();
                }

                return Problem("Not found");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // GET api/<DictionaryesController>/operationtypes
        [HttpGet("operationtypes")]
        public IActionResult GetOperationTypes()
        {
            try
            {
                _logger.LogDebug("api/dictionatryes/operationtypes");
                var types = _dictionaryService.GetOperationTypes();
                var json = JsonConvert.SerializeObject(types);
                return Ok(json);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<DictionaryesController>/userroles
        [HttpGet("userroles")]
        public IActionResult GetUserRoles()
        {
            try
            {
                _logger.LogDebug("api/dictionatryes/userroles");
                var roles = _dictionaryService.GetUserRoles();
                var json = JsonConvert.SerializeObject(roles);
                return Ok(json);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<DictionaryesController>/rightgrids
        [HttpGet("rightgrids")]
        public IActionResult GetRightGrids()
        {
            try
            {
                _logger.LogDebug("api/dictionatryes/rightgrids");
                var rights = _dictionaryService.GetRightsGrids();
                var json = JsonConvert.SerializeObject(rights);
                return Ok(json);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
