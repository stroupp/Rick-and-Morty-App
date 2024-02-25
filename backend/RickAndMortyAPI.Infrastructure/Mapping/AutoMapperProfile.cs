using AutoMapper;
using RickAndMortyAPI.Core.DTOs;
using RickAndMortyAPI.Domain.Entities;

namespace RickAndMortyAPI.Infrastructure.Mapping
{
    public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Character, CharacterDto>()
            .ForMember(dto => dto.Origin, opt => opt.MapFrom(src => src.Origin))
            .ForMember(dto => dto.Location, opt => opt.MapFrom(src => src.Location));

        CreateMap<Origin, OriginDto>();

        CreateMap<Location, LocationDto>();
    }
}

}
