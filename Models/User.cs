using System.ComponentModel.DataAnnotations;

namespace GameAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(100)]
        public string Username { get; set; }
        [Required]
        [StringLength(255)]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(100)]
        public string Nama { get; set; }
        [StringLength(100)]
        public string Alamat { get; set; }

        [Required]
        [StringLength(10)]
        public string Role { get; set; }
    }
}
