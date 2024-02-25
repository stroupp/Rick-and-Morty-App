// File: Core/Interfaces/ICharacterService.cs

using RickAndMortyAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RickAndMortyAPI.Core.Interfaces
{
    public interface ICharacterService
    {
        Task GetAllCharactersAsync();

        Task GetAllEpisodesAndSaveAsync();

        
    }
}
