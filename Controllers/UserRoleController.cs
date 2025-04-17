﻿using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WebLibrary.Application.Services;
using WebLibrary.Data.Dto.Role;
using WebLibrary.Data.Interfaces.Services;
using WebLibrary.Data.Result;

namespace WebLibrary.API.Controllers
{
    /// <summary>
    /// контроллер роли пользователя
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserRoleController(IUserRoleService UserRoleService) : ControllerBase
    {
        private readonly IUserRoleService _UserRoleService = UserRoleService;

        /// <summary>
        /// добавление роли пользователю
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResult<UserRoleDto>>> AddRoleForUserAsync(UserRoleDto dto)
        {
            var result = await _UserRoleService.AddRoleForUserAsync(dto);
            if (result.IsSucces)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        /// <summary>
        /// Обновление роли пользователя
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResult<UserRoleDto>>> UpdateRoleForUserAsync(UpdateUserRoleDto dto)
        {
            var result = await _UserRoleService.UpdateRoleForUserAsync(dto);
            if (result.IsSucces)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        /// <summary>
        /// Удаление роли у пользователя
        /// </summary>
        /// <param name="userLogin"></param>
        /// <param name="RoleName"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResult<UserRoleDto>>> DeleteRoleForUserAsync(string userLogin, string RoleName)
        {
            var result = await _UserRoleService.DeleteRoleForUserAsync(userLogin, RoleName);
            if (result.IsSucces)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
