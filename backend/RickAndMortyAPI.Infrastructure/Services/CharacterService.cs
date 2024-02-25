using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Text.RegularExpressions;


using AutoMapper;
using Newtonsoft.Json;
using RickAndMortyAPI.Domain.Entities;
using RickAndMortyAPI.Infrastructure.Data;
using System.Net.Http.Json;
using RickAndMortyAPI.Core.DTOs;
using RickAndMortyAPI.Core.Interfaces; 

public class CharacterService : ICharacterService
{
    private readonly HttpClient _httpClient;
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _dbContext;
    private const string BaseUrl = "https://rickandmortyapi.com/api";

    public CharacterService(HttpClient httpClient, IMapper mapper, ApplicationDbContext dbContext)
    {
        _httpClient = httpClient;
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public async Task GetAllCharactersAsync()
    {
        var url = $"{BaseUrl}/character";
        await FetchAllDataAsync<CharacterDto>(url, async (dtos) =>
        {
            var characters = _mapper.Map<List<Character>>(dtos);
            _dbContext.Characters.AddRange(characters);
            await _dbContext.SaveChangesAsync();
        });
    }


    public async Task SaveEpisodeAsync(Episode episode)
    {
        _dbContext.Episodes.Add(episode);
        await _dbContext.SaveChangesAsync();
    }


     public async Task GetAllEpisodesAndSaveAsync()
{
    var url = $"{BaseUrl}/episode";
    try
    {
        await FetchAllDataAsync<EpisodeDto>(url, async (dtos) =>
        {
            foreach (var episodeDto in dtos)
            {
                try
                {
                    Episode episode = MapDtoToEntity(episodeDto);
                    if (episode.EpisodeCharacters == null)
                    {
                        episode.EpisodeCharacters = new List<EpisodeCharacter>();
                    }

                    foreach (var characterUrl in episodeDto.Characters)
                    {
                        var characterId = ExtractCharacterId(characterUrl);
                        episode.EpisodeCharacters.Add(new EpisodeCharacter { CharacterId = characterId });
                    }

                    await SaveEpisodeAsync(episode);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error saving episode: {ex.Message}");
                }
            }
        });
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error fetching episodes: {ex.Message}");
    }
}

    private int ExtractCharacterId(string characterUrl)
    {
        var match = Regex.Match(characterUrl, @"(\d+)$");
        return match.Success ? int.Parse(match.Groups[1].Value) : 0;
    }

    private Episode MapDtoToEntity(EpisodeDto episodeDto)
    {
        return new Episode
        {
            Id = episodeDto.Id,
            Name = episodeDto.Name,
            AirDate = ParseAirDate(episodeDto.AirDate),
            EpisodeCode = episodeDto.Episode,
            EpisodeCharacters = new List<EpisodeCharacter>()

          
        };
    }

    private string ParseAirDate(string airDate)
    {
        DateTime parsedDate;
        if (DateTime.TryParse(airDate, out parsedDate))
        {
            return parsedDate.ToString("yyyy-MM-dd"); 
        }
        return null; 
    }

   
    private async Task FetchAllDataAsync<TDto>(string baseUrl, Func<List<TDto>, Task> saveAction)
    {
        List<TDto> allItems = new List<TDto>();
        string nextUrl = baseUrl;
        do
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResult<TDto>>(nextUrl);
            allItems.AddRange(response.Results);
            nextUrl = response.Info.Next;
        }
        while (!string.IsNullOrEmpty(nextUrl));

        if (allItems.Any())
        {
            await saveAction(allItems);
        }
    }

    private class ApiResult<T>
    {
        public Info Info { get; set; }
        public List<T> Results { get; set; }
    }

    private class Info
    {
        public string Next { get; set; }
    }
}
