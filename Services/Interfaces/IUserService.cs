using GameAPI.DTOs.Users;

namespace GameAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDTO?>> GetAllAsync();
        Task<UserResponseDTO?> GetById(int id);
        Task<UserResponseDTO> Create(UserCreateDTO data);
    }
}
