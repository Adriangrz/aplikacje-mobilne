using GameAm.Database.Entities;
using GameAm.Models;

namespace GameAm.Services.Interfaces
{
    public interface IWebPointService
    {
        Task<WebPointDto> CreateWP(CreateWebPointDto dto);
        Task<List<WebPointDto>> GetWPForGame();
        Task DeleteWP(Guid webPointId);
    }
}
