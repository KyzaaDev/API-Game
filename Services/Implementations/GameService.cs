using GameAPI.Data;
using GameAPI.DTOs.Game;
using GameAPI.Models;
using GameAPI.Services.Interfaces;

namespace GameAPI.Services.Implementations
{
    public class GameService : IGameService
    {
        private readonly AppDbContext _context;
        public GameService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<GameResponseDTO> GetAll()
        {
            return _context.Games.Select(g => new GameResponseDTO
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
                NamaGame = newGame.NamaGame,
                Genre = newGame.Genre,
                Harga = newGame.Harga,
                Rating = newGame.Rating
            };

            _context.Games.Add(gameNew);
            _context.SaveChanges();

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
            var game = _context.Games.FirstOrDefault(g => g.Id == id);

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
            var game = _context.Games.FirstOrDefault(g => g.Id == id);
            if (game == null) return false;

            _context.Games.Remove(game);
            _context.SaveChanges();
            return true;
        }

        public GameResponseDTO Update(int id, GameUpdateDTO updGame)
        {
            var game = _context.Games.FirstOrDefault(g => g.Id == id);
            if (game == null) return null;

            game.NamaGame = updGame.NamaGame;
            game.Genre = updGame.Genre;
            game.Rating = updGame.Rating;
            game.Harga = updGame.Harga;
            game.Rating = updGame.Rating;

            _context.SaveChanges();

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
            var query = _context.Games.AsQueryable();

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
