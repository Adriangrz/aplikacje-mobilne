using GameAm.Models;

namespace GameAm.Services.Interfaces
{
    public interface IGameService
    {
        Task<GameDto> CreateGame(CreateGameDto dto);
    }
}
