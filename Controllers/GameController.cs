using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameAPI.Models;
using System.Collections.Generic;

using GameAPI.DTOs;

namespace GameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
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

        [HttpGet]
        public ActionResult<IEnumerable<GameResponseDTO>> GetAll()
        {
            var games = _games.Select(g => new GameResponseDTO
            {
                Id = g.Id,
                NamaGame = g.NamaGame,
                Genre = g.Genre,
                Harga = g.Harga,
                Rating = g.Rating
            }).ToList();

            return games;
        }

        [HttpGet("{id}")]
        public ActionResult<GameResponseDTO> GetById(int id)
        {
            var game = _games.FirstOrDefault(g => g.Id == id);

            if (game == null) return NotFound(new { message = "Data tidak ditemukan" });

            var gameres = new GameResponseDTO
            {
                Id = game.Id,
                NamaGame = game.NamaGame,
                Genre = game.Genre,
                Harga = game.Harga,
                Rating = game.Rating
            };

            return gameres;
        }

        [HttpPost]
        public ActionResult<GameResponseDTO> Create([FromBody] GameCreateDTO newGame)
        {
            var game = new Game
            {
                Id = _games.Max(g => g.Id) + 1,
                NamaGame = newGame.NamaGame,
                Genre = newGame.Genre,
                Harga = newGame.Harga,
                Rating = newGame.Rating,
            };

            _games.Add(game);

            var gameReturn = new GameResponseDTO
            {
                Id = game.Id,
                NamaGame = game.NamaGame,
                Genre = game.NamaGame,
                Harga = game.Harga,
                Rating = game.Rating
            };

            return CreatedAtAction(nameof(GetById), new { id = game.Id }, gameReturn);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] GameUpdateDTO updGame)
        {
            var game = _games.FirstOrDefault(g => g.Id == id);
            if (game == null) return NotFound(new { message = "Data tidak ditemukan" });

            game.NamaGame = updGame.NamaGame;
            game.Genre = updGame.Genre;
            game.Harga = updGame.Harga;
            game.Rating = updGame.Rating;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            var game = _games.FirstOrDefault(g => g.Id == id);
            if (game == null) return NotFound(new { message = "Data tidak ditemukan" });

            _games.Remove(game);

            return NoContent();
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<GameResponseDTO>> Search([FromQuery] string? genre)
        {
            var query = _games.AsQueryable();

            if (!string.IsNullOrEmpty(genre))
            {
                query = query.Where(g => g.Genre.ToLower() == genre.ToLower());
            }

            var games = query.Select(g => new GameResponseDTO
            {
                Id = g.Id,
                NamaGame = g.NamaGame,
                Genre = g.Genre,
                Harga = g.Harga,
                Rating = g.Rating
            }).ToList();

            if (!games.Any())
                return NotFound(new { message = $"Tidak ada game dengan genre {genre}" });

            return Ok(games);
        }


    }
}
