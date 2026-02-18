using System.ComponentModel.DataAnnotations;

namespace GameAPI.DTOs.Game
{
    public class GameCreateDTO
    {
        [Required(ErrorMessage = "Nama game harus diisi")]
        public string NamaGame { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nama developer harus diisi")]
        public string DevName { get; set; }

        [Required(ErrorMessage = "Genre game harus diisi")]
        public string Genre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Harga harus diisi")]
        [Range(1, int.MaxValue, ErrorMessage = "Harga tidak boleh negative")]
        public decimal Harga { get; set; } = decimal.Zero;

        [Required]
        [Range(1, 10, ErrorMessage = "Rating harus pada rentang 1 sampai 10")]
        public double Rating { get; set; } = double.MaxValue;
    }
}
