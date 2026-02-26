using System.ComponentModel.DataAnnotations;

namespace GameAPI.DTOs.Users
{
    public class UserCreateDTO
    {
        [Required(ErrorMessage = "Username wajib diisi.")]
        [StringLength(100, ErrorMessage = "Username maksimal 100 karakter.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password wajib diisi.")]
        [StringLength(255, MinimumLength = 8, ErrorMessage = "Password minimal 8 dan maksimal 255 karakter.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email wajib diisi.")]
        [EmailAddress(ErrorMessage = "Format email tidak valid.")]
        [StringLength(100, ErrorMessage = "Email maksimal 100 karakter.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Nama lengkap wajib diisi.")]
        [StringLength(100, ErrorMessage = "Nama maksimal 100 karakter.")]
        public string Nama { get; set; }

        [StringLength(100, ErrorMessage = "Alamat maksimal 100 karakter.")]
        public string Alamat { get; set; }

        [Required(ErrorMessage = "Role wajib ditentukan.")]
        [StringLength(10, ErrorMessage = "Role maksimal 10 karakter.")]
        public string Role { get; set; }
    }
}
