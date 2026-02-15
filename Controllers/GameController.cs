using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameAPI.Models;
using System.Collections.Generic;
using GameAPI.DTOs.Game;
using GameAPI.Services.Interfaces;

namespace GameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GameResponseDTO>> GetAll()
        {
            var games = _gameService.GetAll();
            return Ok(games);
        }

        [HttpGet("{id}")]
        public ActionResult<GameResponseDTO> GetById(int id)
        {
            var gameres = _gameService.GetById(id);
            if (gameres == null) return NotFound(new { message = "Data tidak ditemukan" });

            return gameres;
        }

        [HttpPost]
        public ActionResult<GameResponseDTO> Create([FromBody] GameCreateDTO newGame)
        {
            var game = _gameService.Create(newGame);
            return Ok(game);
            //return CreatedAtAction(nameof(GetById), new { id = game.Id }, gameReturn);
        }

        //[HttpPut("{id}")]
        //public IActionResult Update(int id, [FromBody] GameUpdateDTO updGame)
        //{
        //    var game = _games.FirstOrDefault(g => g.Id == id);
        //    if (game == null) return NotFound(new { message = "Data tidak ditemukan" });

        //    game.NamaGame = updGame.NamaGame;
        //    game.Genre = updGame.Genre;
        //    game.Harga = updGame.Harga;
        //    game.Rating = updGame.Rating;

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult delete(int id)
        //{
        //    var game = _games.FirstOrDefault(g => g.Id == id);
        //    if (game == null) return NotFound(new { message = "Data tidak ditemukan" });

        //    _games.Remove(game);

        //    return NoContent();
        //}

        //[HttpGet("search")]
        //public ActionResult<IEnumerable<GameResponseDTO>> Search([FromQuery] string? genre)
        //{
        //    var query = _games.AsQueryable();

        //    if (!string.IsNullOrEmpty(genre))
        //    {
        //        query = query.Where(g => g.Genre.ToLower() == genre.ToLower());
        //    }

        //    var games = query.Select(g => new GameResponseDTO
        //    {
        //        Id = g.Id,
        //        NamaGame = g.NamaGame,
        //        Genre = g.Genre,
        //        Harga = g.Harga,
        //        Rating = g.Rating
        //    }).ToList();

        //    if (!games.Any())
        //        return NotFound(new { message = $"Tidak ada game dengan genre {genre}" });

        //    return Ok(games);
        //}


    }
}
