using Microsoft.AspNetCore.Mvc;
using RickAndMortyAPI.Core.Interfaces;
using System.Threading.Tasks;
using RickAndMortyAPI.Core.DTOs;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace RickAndMortyAPI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RickAndMortyController : ControllerBase
    {
        private readonly IRickAndMortyService _rickAndMortyService;
         private readonly IHttpClientFactory _clientFactory;

        public RickAndMortyController(IRickAndMortyService rickAndMortyService, IHttpClientFactory clientFactory)
        {
            _rickAndMortyService = rickAndMortyService;
            _clientFactory = clientFactory;

        }

        [HttpGet("characters")]
        public async Task<IActionResult> GetCharacters()
        {
            var characters = await _rickAndMortyService.GetCharactersAsync();
            return Ok(characters);
        }

        [HttpGet("episodes")]
        public async Task<IActionResult> GetEpisodes()
        {
            var episodes = await _rickAndMortyService.GetEpisodesAsync();
            return Ok(episodes);
        }

        [HttpGet("characters/{id}")]
        public async Task<IActionResult> GetCharacterById(int id)
        {
            var characterDto = await _rickAndMortyService.GetCharacterByIdAsync(id);
            if (characterDto == null) return NotFound();
            return Ok(characterDto);
        }

        [HttpGet("episodes/{id}")]
        public async Task<ActionResult<EpisodeDto>> GetEpisode(int id)
        {
            var episodeDto = await _rickAndMortyService.GetEpisodeByIdAsync(id);
            if (episodeDto == null)
            {
                return NotFound();
            }
            return Ok(episodeDto);
        }

         [HttpGet("episodes/count")]
        public async Task<IActionResult> GetEpisodesCountAndPages()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, 
                "https://rickandmortyapi.com/api/episode/");
            request.Headers.Add("Accept", "application/json");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var jObject = await JObject.LoadAsync(new Newtonsoft.Json.JsonTextReader(new StreamReader(responseStream)));
                var info = jObject["info"];
                var result = new
                {
                    count = (int)info["count"],
                    pages = (int)info["pages"]
                };
                return Ok(result);
            }
            else
            {
                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            }
        }

        
    }
}
