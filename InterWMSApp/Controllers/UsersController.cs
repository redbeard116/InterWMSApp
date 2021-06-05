using System;
using System.Security.Claims;
using System.Threading.Tasks;
using InterWMSApp.Models;
using InterWMSApp.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace InterWMSApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        #region Fields
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;
        #endregion

        #region Constructor
        public UsersController(ILogger<UsersController> logger,
                              IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        #endregion

        #region Actions
        /// <summary>
        /// Получение всех арендоторов
        /// </summary>
        /// <returns>Возвращает все арендаторов</returns>
        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetAllUser()
        {
            _logger.LogInformation("get api/user");

            var user = _userService.GetUsers();
            if (user != null)
            {
                return Ok(JsonConvert.SerializeObject(user));
            }
            return BadRequest("Ошибка при получении задании");
        }

        /// <summary>
        /// Возвращает конкретного арендатора
        /// </summary>
        /// <param name="id">Id продукта</param>
        /// <returns>Найденный продукт</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUser(int id)
        {
            _logger.LogInformation($"get api/users/{id}");

            var user = await _userService.GetUser(id);
            if (user != null)
            {
                return Ok(JsonConvert.SerializeObject(user));
            }
            return BadRequest("Ошибка при получении задания");
        }

        /// <summary>
        /// Возвращает текущего пользователя
        /// </summary>
        /// <returns>Найденный продукт</returns>
        [HttpGet("currentuser")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {
            _logger.LogInformation($"getcurrentuser api/users/currentuser");
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userService.GetUser(Convert.ToInt32(userId));
            if (user != null)
            {
                return Ok(JsonConvert.SerializeObject(user));
            }
            return BadRequest("Ошибка при получении задания");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            _logger.LogInformation($"add api/users");

            var iser = User;
            int? id = await _userService.AddUser(user);
            if (id.HasValue)
            {
                user.Id = id.Value;
                return Ok(JsonConvert.SerializeObject(user));
            }
            return BadRequest("Ошибка при создании задания");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            _logger.LogInformation($"delete api/users/{id}");

            var result = await _userService.DeleteUser(id);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Ошибка при удалении задания");
        }

        [HttpPut("edit")]
        [Authorize]
        public async Task<IActionResult> EditUser([FromBody] User user)
        {
            _logger.LogInformation($"patch api/users/edit/{user.Id}");

            var result = await _userService.EditUser(user);
            if (result != null)
            {
                return Ok(JsonConvert.SerializeObject(result));
            }
            return BadRequest("Ошибка при изменении задания");
        }
        #endregion
    }
}
