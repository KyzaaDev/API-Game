using GameAPI.DTOs.Users;
using GameAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService ser)
        {
            _userService = ser;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponseDTO?>>> GetAll()
        {
            try
            {
                var users = await _userService.GetAllAsync();
                return Ok(users);
            }
            catch(Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponseDTO?>> GetById(int id)
        {
            try
            {
                var user = await _userService.GetById(id);
                return user;
            }
            catch(Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<UserResponseDTO?>> Create(UserCreateDTO data)
        {
            var user = await _userService.Create(data);
            return CreatedAtAction(nameof(GetById), new { id = user.UserId }, user);
        }
    }
}
