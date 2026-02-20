using GameAPI.DTOs.Game;

namespace GameAPI.Services.Interfaces   
{
    public interface IGameService
    {
        Task<IEnumerable<GameResponseDTO>> GetAll();
        Task<GameResponseDTO> Create(GameCreateDTO newGame);
        Task<GameResponseDTO> GetById(int id);
        Task<bool> Delete(int id);
        Task<GameResponseDTO?> Update(int id, GameUpdateDTO updGame);
        Task<IEnumerable<GameResponseDTO>> GetByGenre(string? genre);
        Task<IEnumerable<GameResponseDTO>> FilterGames(string? genre, string? devname, decimal? harga);
    }
}
