using GameAPI.Data;
using GameAPI.DTOs.Category;
using GameAPI.DTOs.Game;
using GameAPI.Models;
using GameAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameAPI.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        public readonly AppDbContext _context;
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryResponseDTO>> GetAllAsync()
        {
            var data = await _context.Categories.Select(c => new CategoryResponseDTO
            {
                Id = c.Id,
                Category = c.CategoryName,
                Games = c.Games.Select( g => new GameResponseDTO
                {
                    Id = g.Id,
                    NamaGame = g.NamaGame,
                    Harga = g.Harga,
                    Rating = g.Rating,
                    Genre = g.Genre
                }).ToList(),
            }).ToListAsync();

            if (data == null) return null;
            return data;
        }
        public async Task<CategoryResponseDTO> CreateAsync(CategoryCreateDTO data)
        {
            var newCategory = new Category
            {
                CategoryName = data.CategoryName
            };

            _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync();

            return new CategoryResponseDTO
            {
                Id = newCategory.Id,
                Category = newCategory.CategoryName,
                Games = newCategory.Games.Select(g => new GameResponseDTO
                {
                    Id = g.Id,
                    NamaGame = g.NamaGame,
                    Harga = g.Harga,
                    Rating = g.Rating,
                    Genre = g.Genre
                }).ToList(),
            };
        }

        public async Task<CategoryResponseDTO?> GetById(int id)
        {
            var cat = await _context.Categories.Include(g => g.Games).FirstOrDefaultAsync(c => c.Id == id);

            if (cat == null) return null;
            return new CategoryResponseDTO
            {
                Id = cat.Id,
                Category = cat.CategoryName,
                Games = cat.Games.Select(g => new GameResponseDTO
                {
                    Id = g.Id,
                    NamaGame = g.NamaGame,
                    Harga = g.Harga,
                    Rating = g.Rating,
                    Genre = g.Genre
                }).ToList()
            };

        }
    }
}
