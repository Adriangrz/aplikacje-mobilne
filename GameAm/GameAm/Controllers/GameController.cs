using GameAm.Models;
using GameAm.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameAm.Controllers
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

        [HttpPost]
        public async Task<ActionResult<GameDto>> CreateWebPoint([FromBody] CreateGameDto dto)
        {
            var game = await _gameService.CreateGame(dto);

            return Ok(game);
        }
    }
}
