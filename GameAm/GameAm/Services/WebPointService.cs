using AutoMapper;
using GameAm.Database;
using GameAm.Database.Entities;
using GameAm.Models;
using GameAm.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace GameAm.Services
{
    public class WebPointService : IWebPointService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public WebPointService(IMapper mapper, ApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<WebPointDto> CreateWP(CreateWebPointDto dto, Guid gameId)
        {
            var webPoint = _mapper.Map<WebPoint>(dto);
            webPoint.GameId = gameId;
            await _dbContext.WebPoints.AddAsync(webPoint);
            await _dbContext.SaveChangesAsync();

            var webPointDto = _mapper.Map<WebPointDto>(webPoint);
            return webPointDto;
        }

        public async Task<List<WebPointDto>> GetWPForGame(Guid gameId)
        {
            var webPoints = await _dbContext.WebPoints.Where(wp => wp.GameId == gameId).ToListAsync();

            var webPointsDtos = _mapper.Map<List<WebPointDto>>(webPoints);
            return webPointsDtos;
        }

        public async Task DeleteWP(Guid webPointId)
        {
            var webPoint = await _dbContext.WebPoints.FirstOrDefaultAsync(wp => wp.Id == webPointId);

            _dbContext.WebPoints.Remove(webPoint);
            await _dbContext.SaveChangesAsync();
        }
    }
}
