using System.ComponentModel.DataAnnotations;

namespace GameAPI.DTOs.Auths
{
    public class LoginRequestDTO
    {
        [Required(ErrorMessage = "Isi username terlebih dahulu")]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "Isi password terlebih dahulu")]
        public string Password { get; set; } = string.Empty;
    }
}
