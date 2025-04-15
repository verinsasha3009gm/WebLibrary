using Microsoft.AspNetCore.Mvc;
using WebLibrary.Data.Dto.Book;
using WebLibrary.Data.Interfaces.Services;
using WebLibrary.Data.Result;

namespace WebLibrary.API.Controllers
{
    /// <summary>
    /// Контроллер по работе с книгами
    /// </summary>
    /// <param name="bookService"></param>
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BookController(IBookService bookService) : ControllerBase
    {
        private readonly IBookService _bookService = bookService;
        /// <summary>
        /// запрос по поиску книг 
        /// </summary>
        /// <param name="Price"></param>
        /// <param name="Category"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<BaseResult<BookDto>>> IndexBookAsync(decimal Price,string Category)
        {
            var result = await _bookService.IndexAsync(Price,Category);
            if (result.IsSucces)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        /// <summary>
        /// запрос по созданию книги
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<BaseResult<BookDto>>> CreateBookAsync(CreateBookDto dto)
        {
            var result = await _bookService.CreateBookAsync(dto);
            if (result.IsSucces)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        /// <summary>
        /// запрос по обновлению книги
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<BaseResult<BookDto>>> UpdateBookAsync(UpdateBookDto dto)
        {
            var result = await _bookService.UpdateBookAsync(dto);
            if (result.IsSucces)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        /// <summary>
        /// запрос по удалению книги
        /// </summary>
        /// <param name="Title"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult<BaseResult<BookDto>>> DeleteBookAsync(string Title)
        {
            var result = await _bookService.DeleteBookAsync(Title);
            if (result.IsSucces)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
