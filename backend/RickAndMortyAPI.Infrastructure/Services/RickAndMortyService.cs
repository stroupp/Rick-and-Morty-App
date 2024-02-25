using AutoMapper;
using RickAndMortyAPI.Core.DTOs;
using RickAndMortyAPI.Core.Interfaces;
using RickAndMortyAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RickAndMortyAPI.Infrastructure.Services
{
    public class RickAndMortyService : IRickAndMortyService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;

        public RickAndMortyService(ApplicationDbContext context, IMapper mapper, HttpClient httpClient)
        {
            _context = context;
            _mapper = mapper;
            _httpClient = httpClient;
        }

        public async Task<CharacterDto> GetCharacterByIdAsync(int id)
{
    var character = await _context.Characters
        .Include(c => c.Origin)
        .Include(c => c.Location)
        .FirstOrDefaultAsync(c => c.Id == id);

  

    if (character == null) return null;

    return _mapper.Map<CharacterDto>(character); 
}

        public async Task<IEnumerable<CharacterDto>> GetCharactersAsync()
        {
            var characters = await _context.Characters
                .Include(c => c.EpisodeCharacters)
                .ToListAsync();

            return _mapper.Map<IEnumerable<CharacterDto>>(characters);
        }

        

        public async Task<IEnumerable<EpisodeDto>> GetEpisodesAsync()
        {
            var episodes = await _context.Episodes
                .Include(e => e.EpisodeCharacters)
                .ToListAsync();

            return _mapper.Map<IEnumerable<EpisodeDto>>(episodes);
        }

        public async Task<EpisodeDto> GetEpisodeByIdAsync(int episodeId)
{
    var episode = await _context.Episodes
        .Where(e => e.Id == episodeId)
        .Select(e => new 
        {
            e.Id,
            e.Name,
            e.AirDate,
            e.EpisodeCode,
            Characters = e.EpisodeCharacters.Select(ec => ec.CharacterId.ToString()).ToList() 
        })
        .FirstOrDefaultAsync();

    if (episode == null) return null;

   
    var episodeDto = new EpisodeDto
    {
        Id = episode.Id,
        Name = episode.Name,
        AirDate = episode.AirDate,
        Episode = episode.EpisodeCode,
        Characters = episode.Characters
    };

    return episodeDto;
}

    }
}
