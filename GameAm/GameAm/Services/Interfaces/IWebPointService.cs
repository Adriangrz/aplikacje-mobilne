using GameAm.Database.Entities;
using GameAm.Models;

namespace GameAm.Services.Interfaces
{
    public interface IWebPointService
    {
        Task<WebPointDto> CreateWP(CreateWebPointDto dto, Guid gameId);
        Task<List<WebPointDto>> GetWPForGame(Guid gameId);
        Task DeleteWP(Guid webPointId);
    }
}
