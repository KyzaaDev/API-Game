using System.ComponentModel.DataAnnotations;

namespace GameAPI.DTOs.Game
{
    public class GameUpdateDTO
    {
        [Required(ErrorMessage = "Nama game harus diisi")]
        public string NamaGame { get; set; } = string.Empty;

        [Required(ErrorMessage = "Genre game harus diisi")]
        public string Genre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Harga harus diisi")]
        public decimal Harga { get; set; } = decimal.Zero;

        [Required]
        [Range(1, 10, ErrorMessage = "Rating harus pada rentang 1 sampai 10")]
        public double Rating { get; set; } = double.MaxValue;
    }
}
