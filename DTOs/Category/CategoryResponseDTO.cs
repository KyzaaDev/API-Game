using GameAPI.DTOs.Game;
using GameAPI.Models;

namespace GameAPI.DTOs.Category
{
    public class CategoryResponseDTO
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public List<GameResponseDTO> Games { get; set; } = new List<GameResponseDTO>();
    }
}
