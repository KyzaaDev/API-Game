using GameAPI.DTOs.Category;
using GameAPI.Services.Implementations;
using GameAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryResponseDTO>>> GetAllAsync()
        {
            var data = await _categoryService.GetAllAsync();
            if (data == null) return NotFound(new { message = "Belum ada data" });
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResponseDTO>> GetById(int id)
        {
            var gameres = await _categoryService.GetById(id);
            if (gameres == null) return NotFound(new { message = $"Data dengan ID {id} tidak ditemukan" });

            return Ok(gameres);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryResponseDTO>> CreateAsync(CategoryCreateDTO data)
        {
            var newCat = await _categoryService.CreateAsync(data);
            return CreatedAtAction(nameof(GetById), new {id = newCat.Id }, newCat);
        }
    }
}
