using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameAPI.Models;
using System.Collections.Generic;
using GameAPI.DTOs.Game;
using GameAPI.Services.Interfaces;
using GameAPI.Data;

namespace GameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GameController(IGameService gameService, AppDbContext context)
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
            return CreatedAtAction(nameof(GetById), new { id = game.Id }, game);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] GameUpdateDTO updGame)
        {
            var game = _gameService.Update(id, updGame);
            if (game == null) return NotFound(new { message = "Data tidak ditemukan" });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            var game = _gameService.Delete(id);
            if (game == false) return NotFound(new { message = "Data tidak ditemukan" });

            return NoContent();
        }

        [HttpGet("search")] 
        public ActionResult<IEnumerable<GameResponseDTO>> GetByGenre([FromQuery] string? genre)
        {
            var results = _gameService.GetByGenre(genre);
            if (results == null && !results.Any()) return NotFound(new { message = $"Tidak ada game dengan genre {genre}" });
            return Ok(results);

        }


    }
}
