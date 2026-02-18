using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
namespace GameAPI.Models

{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "Nama game tidak boleh lebih dari 100 character")]
        public string NamaGame { get; set; }

        [StringLength(100)]
        public string DevName { get; set; }

        [MaxLength(100, ErrorMessage = "Genre tidak boleh lebih dari 100 character")]
        public string Genre { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Harga { get; set; }

        [Range(1,10, ErrorMessage = "Rating harus pada rentang 1 sampai 10")]
        public double Rating { get; set; }
    }
}
