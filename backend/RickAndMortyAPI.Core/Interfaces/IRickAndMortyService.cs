// RickAndMortyAPI.Core/Interfaces/IRickAndMortyService.cs
using RickAndMortyAPI.Core.DTOs;

namespace RickAndMortyAPI.Core.Interfaces;

public interface IRickAndMortyService
{
    Task<IEnumerable<CharacterDto>> GetCharactersAsync();
    Task<IEnumerable<EpisodeDto>> GetEpisodesAsync();

    Task<CharacterDto> GetCharacterByIdAsync(int id);

    Task<EpisodeDto> GetEpisodeByIdAsync(int episodeId);

}