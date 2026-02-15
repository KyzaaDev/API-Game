using GameAPI.DTOs.Game;
using GameAPI.Models;
using GameAPI.Services.Interfaces;

namespace GameAPI.Services.Implementations
{
    public class GameService : IGameService
    {
        private static List<Game> _games = new List<Game>
        {
            new Game { Id = 1, NamaGame = "The Witcher 3", Genre = "RPG", Harga = 350000, Rating = 9.8 },
            new Game { Id = 2, NamaGame = "FIFA 23", Genre = "Sports", Harga = 750000, Rating = 8.5 },
            new Game { Id = 3, NamaGame = "Call of Duty: Modern Warfare", Genre = "FPS", Harga = 900000, Rating = 8.9 },
            new Game { Id = 4, NamaGame = "Minecraft", Genre = "Sandbox", Harga = 300000, Rating = 9.5 },
            new Game { Id = 5, NamaGame = "Genshin Impact", Genre = "Action RPG", Harga = 0, Rating = 8.7 },
            new Game { Id = 6, NamaGame = "Grand Theft Auto V", Genre = "Action", Harga = 450000, Rating = 9.6 },
            new Game { Id = 7, NamaGame = "Red Dead Redemption 2", Genre = "Adventure", Harga = 600000, Rating = 9.7 },
            new Game { Id = 8, NamaGame = "Valorant", Genre = "Tactical FPS", Harga = 0, Rating = 8.3 },
            new Game { Id = 9, NamaGame = "Elden Ring", Genre = "Action RPG", Harga = 850000, Rating = 9.4 },
            new Game { Id = 10, NamaGame = "Cyberpunk 2077", Genre = "RPG", Harga = 700000, Rating = 8.1 }
        };

        public IEnumerable<GameResponseDTO> GetAll()
        {
            return _games.Select(g => new GameResponseDTO
            {
                Id = g.Id,
                NamaGame = g.NamaGame,
                Genre = g.Genre,
                Harga = g.Harga,
                Rating = g.Rating
            }).ToList();
        }

        public GameResponseDTO Create(GameCreateDTO newGame)
        {
            var gameNew = new Game
            {
                Id = _games.Any() ? _games.Max(g => g.Id)+ 1 : 1,
                NamaGame = newGame.NamaGame,
                Genre = newGame.Genre,
                Harga = newGame.Harga,
                Rating = newGame.Rating
            };

            _games.Add(gameNew);

            return new GameResponseDTO
            {
                Id = gameNew.Id,
                NamaGame = gameNew.NamaGame,
                Genre = gameNew.Genre,
                Harga = gameNew.Harga,
                Rating = gameNew.Rating
            };
        }

        public GameResponseDTO? GetById(int id)
        {
            var game = _games.FirstOrDefault(g => g.Id == id);

            if (game == null) return null;

            return new GameResponseDTO
            {
                Id = game.Id,
                NamaGame = game.NamaGame,
                Genre = game.Genre,
                Harga = game.Harga,
                Rating = game.Rating
            };
        }

        public bool Delete(int id)
        {
            var game = _games.FirstOrDefault(g => g.Id == id);
            if (game == null) return false;

            _games.Remove(game);
            return true;
        }

        public GameResponseDTO Update(int id, GameUpdateDTO updGame)
        {
            var game = _games.FirstOrDefault(g => g.Id == id);
            if (game == null) return null;

            game.NamaGame = updGame.NamaGame;
            game.Genre = updGame.Genre;
            game.Rating = updGame.Rating;
            game.Harga = updGame.Harga;

            return new GameResponseDTO
            {
                Id = game.Id,
                NamaGame = game.NamaGame,
                Genre = game.Genre,
                Rating = game.Rating,
                Harga = game.Harga
            };
        }

        public IEnumerable<GameResponseDTO> GetByGenre(string? genre)
        {
            var query = _games.AsQueryable();

            if (!string.IsNullOrEmpty(genre))
            {
                query = query.Where(g => g.Genre.Contains(genre, StringComparison.CurrentCultureIgnoreCase));
            }

            var games = query.Select(g => new GameResponseDTO
            {
                Id = g.Id,
                NamaGame = g.NamaGame,
                Genre = g.Genre,
                Harga = g.Harga,
                Rating = g.Rating
            }).ToList();

            return games;
        }
    }
}
