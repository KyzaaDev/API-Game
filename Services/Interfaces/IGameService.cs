using GameAPI.DTOs.Game;

namespace GameAPI.Services.Interfaces   
{
    public interface IGameService
    {
        IEnumerable<GameResponseDTO> GetAll();
        GameResponseDTO Create(GameCreateDTO newGame);
        GameResponseDTO GetById(int id);
    }
}
