using Microsoft.AspNetCore.Mvc;
using WebLibrary.Data.Dto.Order;
using WebLibrary.Data.Interfaces.Services;
using WebLibrary.Data.Result;

namespace WebLibrary.API.Controllers
{
    /// <summary>
    /// Контроллер для работы с корзиной
    /// </summary>
    /// <param name="orderService"></param>
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class OrderController(IOrderService orderService) : ControllerBase
    {
        private readonly IOrderService _orderService = orderService;
        /// <summary>
        /// Запрос на получение корзины пользователя
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task <ActionResult<BaseResult<OrderDto>>> GetOrderAsync(string Email)
        {
            var result = await _orderService.GetOrderAsync(Email);
            if (result.IsSucces)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        /// <summary>
        /// Запрос на создание корзины у пользователя
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<BaseResult<OrderDto>>> CreateOrderAsync(CreateOrderDto dto)
        {
            var result = await _orderService.CreateOrderAsync(dto);
            if (result.IsSucces)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        /// <summary>
        /// Запрос на обновление корзины у пользователя
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<BaseResult<OrderDto>>> UpdateOrderAsync(UpdateOrderDto dto)
        {
            var result = await _orderService.UpdateOrderAsync(dto);
            if (result.IsSucces)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        /// <summary>
        /// Запрос на удаление корзины у пользователя
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult<BaseResult<OrderDto>>> DeleteOrderAsync(string Email)
        {
            var result = await _orderService.DeleteOrderAsync(Email);
            if (result.IsSucces)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
