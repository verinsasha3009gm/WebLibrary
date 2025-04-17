using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WebLibrary.Data.Dto;
using WebLibrary.Data.Interfaces.Services;
using WebLibrary.Data.Result;

namespace WebLibrary.API.Controllers
{
    /// <summary>
    /// Контроллер по работе с токенами
    /// </summary>
    /// <param name="tokenService"></param>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TokenController(ITokenService tokenService) : ControllerBase
    {
        private readonly ITokenService _tokenService = tokenService;

        /// <summary>
        /// получение прав авторизованного пользователя(бновление токена)
        /// </summary>
        /// <param name="tokenDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Refresh")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResult<TokenDto>>> RefreshToken([FromBody] TokenDto tokenDto)
        {
            var response = await _tokenService.RefreshToken(tokenDto);
            if (response.IsSucces)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
