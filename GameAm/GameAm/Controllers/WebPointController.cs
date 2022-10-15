using GameAm.Database.Entities;
using GameAm.Models;
using GameAm.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameAm.Controllers
{
    [Route("api/Game/{gameId}/[controller]")]
    [ApiController]
    public class WebPointController : ControllerBase
    {
        private readonly IWebPointService _webPointService;
        public WebPointController(IWebPointService webPointService)
        {
            _webPointService = webPointService;
        }
        [HttpGet]
        public async Task<ActionResult<List<WebPointDto>>> GetAll([FromRoute] Guid gameId)
        {
            var result = await _webPointService.GetWPForGame(gameId);

            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<WebPointDto>> CreateWebPoint([FromBody] CreateWebPointDto dto, [FromRoute] Guid gameId)
        {
            var webPoint = await _webPointService.CreateWP(dto,gameId);

            return Ok(webPoint);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            await _webPointService.DeleteWP(id);

            return Ok();
        }
    }
}
