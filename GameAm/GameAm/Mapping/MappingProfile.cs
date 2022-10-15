using AutoMapper;
using GameAm.Database.Entities;
using GameAm.Models;

namespace GameAm.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WebPoint, WebPointDto>().ReverseMap();
            CreateMap<CreateWebPointDto, WebPoint>();
            CreateMap<Game, GameDto>().ReverseMap();
            CreateMap<CreateGameDto, Game>();
        }
    }
}
