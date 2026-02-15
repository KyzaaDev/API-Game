using System.ComponentModel.DataAnnotations;
namespace GameAPI.Models

{
    public class Game
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nama game harus diisi")]
        public string NamaGame { get; set; }

        [Required(ErrorMessage = "Genre game harus diisi")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Harga harus diisi")]
        public decimal Harga { get; set; }

        [Required]
        [Range(1,10, ErrorMessage = "Rating harus pada rentang 1 sampai 10")]
        public double Rating { get; set; }
    }
}
