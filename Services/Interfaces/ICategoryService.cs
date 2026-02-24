using GameAPI.DTOs.Category;

namespace GameAPI.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponseDTO>> GetAllAsync();
        Task<CategoryResponseDTO> CreateAsync(CategoryCreateDTO data);
        Task<CategoryResponseDTO?> GetById(int id);
    }
}
