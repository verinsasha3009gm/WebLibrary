using Microsoft.AspNetCore.Mvc;
using WebLibrary.Application.Services;
using WebLibrary.Data.Dto.Book;
using WebLibrary.Data.Dto.Category;
using WebLibrary.Data.Interfaces.Services;
using WebLibrary.Data.Result;

namespace WebLibrary.API.Controllers
{
    /// <summary>
    /// Контроллер по работе с категориями
    /// </summary>
    /// <param name="categoryService"></param>
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CategoryController(ICategoryService categoryService) : ControllerBase
    {
        private readonly ICategoryService _categoryService = categoryService;
        /// <summary>
        /// Чтение категории из бд
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<BaseResult<CategoryDto>>> GetCategoryAsync(string category)
        {
            var result = await _categoryService.GetCategoryAsync(category);
            if (result.IsSucces)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        /// <summary>
        /// Создание категории
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<BaseResult<CategoryDto>>> CreateCategoryAsync(CreateCategoryDto dto)
        {
            var result = await _categoryService.CreateCategoryAsync(dto);
            if (result.IsSucces)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        /// <summary>
        /// Обновление категории 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<BaseResult<CategoryDto>>> UpdateCatgoryAsync(UpdateCategoryDto dto)
        {
            var result = await _categoryService.UpdateCategoryAsync(dto);
            if (result.IsSucces)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        /// <summary>
        /// Удаление категории
        /// </summary>
        /// <param name="Category"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult<BaseResult<CategoryDto>>> DeleteCategoryAsync(string Category)
        {
            var result = await _categoryService.DeleteCategoryAsync(Category);
            if (result.IsSucces)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
