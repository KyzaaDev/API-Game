using GameAPI.DTOs.Auths;
using GameAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService ser)
        {
            _authService = ser;
        }

        [HttpPost]
        public async Task<ActionResult<AuthResponseDTO>> Login(LoginRequestDTO login)
        {
            try
            {
                var loginUser = await _authService.Login(login);
                return loginUser;

            }
            catch(Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }
    }
}
