using AutoMapper;
using GameAm.Database.Entities;
using GameAm.Database;
using GameAm.Models;
using GameAm.Services.Interfaces;

namespace GameAm.Services
{
    public class GameService : IGameService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public GameService(IMapper mapper, ApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<GameDto> CreateGame(CreateGameDto dto)
        {
            var game = _mapper.Map<Game>(dto);
            await _dbContext.Games.AddAsync(game);
            await _dbContext.SaveChangesAsync();

            var gameDto = _mapper.Map<GameDto>(game);
            return gameDto;
        }
    }
}
