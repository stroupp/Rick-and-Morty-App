using AutoMapper;
using RickAndMortyAPI.Core.DTOs;
using RickAndMortyAPI.Domain.Entities;

namespace RickAndMortyAPI.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CharacterDto, Character>()
                .ForMember(dest => dest.Origin, opt => opt.MapFrom(src => new Origin { Name = src.Origin.Name }))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => new Location { Name = src.Location.Name }));

            CreateMap<Character, CharacterDto>()
                .ForMember(dest => dest.Origin, opt => opt.MapFrom(src => new Origin { Name = src.Origin.Name }))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => new Location { Name = src.Location.Name }));
            CreateMap<Episode, EpisodeDto>();

        }
    }
}
