using Microsoft.AspNetCore.Mvc;
using WebLibrary.DAL.Repository;
using WebLibrary.Data.Dto.Book;
using WebLibrary.Data.Dto.OrderLine;
using WebLibrary.Data.Interfaces.Services;
using WebLibrary.Data.Result;

namespace WebLibrary.API.Controllers
{
    /// <summary>
    /// Контроллер для запросов по работе с позицией в корзине пользователя
    /// </summary>
    /// <param name="orderLineService"></param>
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class OrderLineController(IOrderLineService orderLineService) : ControllerBase
    {
        private readonly IOrderLineService _orderLineService = orderLineService;
        /// <summary>
        /// Чтение всех книг в корзине пользователя
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        [HttpGet("All")]
        public async Task<ActionResult<CollectionResult<BookDto>>> GetBooksInOrderAsync(string Email)
        {
            var result = await _orderLineService.GetBooksInOrderAsync(Email);
            if (result.IsSucces)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        /// <summary>
        /// Чтение книги из корзины пользователя по автору и названию
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Title"></param>
        /// <param name="Author"></param>
        /// <returns></returns>
        [HttpGet("One")]
        public async Task<ActionResult<BaseResult<BookDto>>> GetBooksInOrderAsync(string Email,string Title,string Author)
        {
            var result = await _orderLineService.GetBookInOrderAsync(Email, Title, Author);
            if (result.IsSucces)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        /// <summary>
        /// Добавлениеодной книги в корзину
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<BaseResult<BookDto>>> AddBookOneOnOrderAsync(AddBookInOrderDto dto)
        {
            var result = await _orderLineService.AddBookOneInOrder(dto);
            if (result.IsSucces)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        /// <summary>
        /// Удаление всех книг в позиции
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Title"></param>
        /// <returns></returns>
        [HttpDelete("All")]
        public async Task<ActionResult<BaseResult<BookDto>>> RemoveBooksAllInOrder(string Email, string Title)
        {
            var result = await _orderLineService.RemoveBooksAllInOrder(Email,Title);
            if (result.IsSucces)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        /// <summary>
        /// Удалениен одной книги в позиции
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Title"></param>
        /// <returns></returns>
        [HttpDelete("One")]
        public async Task<ActionResult<BaseResult<BookDto>>> RemoveBookOneInOrder(string Email,string Title)
        {
            var result = await _orderLineService.RemoveBookOneInOrder(Email, Title);
            if (result.IsSucces)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
