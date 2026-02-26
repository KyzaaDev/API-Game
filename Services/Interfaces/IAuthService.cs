using GameAPI.DTOs.Auths;

namespace GameAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDTO> Login(LoginRequestDTO login);
    }
}
