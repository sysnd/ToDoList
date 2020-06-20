using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Server.Services.Users;
using ToDoList.Shared.Models;

namespace ToDoList.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger,
            IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var result = _userService.GetAll().ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {
            try
            {
                var result = await _userService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            try
            {
                var result = await _userService.Create(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            try
            {
                var result = await _userService.Update(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            try
            {
                var result = await _userService.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
