using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WebLibrary.Data.Dto.User;
using WebLibrary.Data.Dto;
using WebLibrary.Data.Interfaces.Services;
using WebLibrary.Data.Result;

namespace WebLibrary.API.Controllers
{
    /// <summary>
    /// Контроллер Пользователя
    /// </summary>
    /// <param name="userService"></param>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _UserService = userService;

        /// <summary>
        /// Запрос на считывание всех пользователей из бд
        /// </summary>
        /// <returns></returns>
        [HttpGet("AllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CollectionResult<UserDto>>> GetAllUsersAsync()
        {
            var result = await _UserService.GetAllUsersAsync();
            if (result.IsSucces)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        /// <summary>
        /// Запрос на получение одного пользователя из бд
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        [HttpGet("User/{userLogin}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResult<UserDto>>> GetUserAsync(string userLogin)
        {
            var result = await _UserService.GetUserAsync(userLogin);
            if (result.IsSucces)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("Registration")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResult<UserDto>>> RegistrationUserAsync(RegistrationUserDto dto)
        {
            var result = await _UserService.RegistrationUserAsync(dto);
            if (result.IsSucces)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        /// <summary>
        /// Вход пользователя
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResult<TokenDto>>> LoginUserAsync(LoginUserDto dto)
        {
            var result = await _UserService.LoginUserAsync(dto);
            if (result.IsSucces)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        /// <summary>
        /// Обновление пользователя
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResult<UserDto>>> UpdateUserAsync(UpdateUserDto dto)
        {
            var result = await _UserService.UpdateUserAsync(dto);
            if (result.IsSucces)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResult<UserDto>>> DeleteUserAsync(string Email, string password)
        {
            var result = await _UserService.DeleteUserAsync(Email, password);
            if (result.IsSucces)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
    }
}
