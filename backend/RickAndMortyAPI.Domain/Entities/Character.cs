// Updated RickAndMortyAPI.Domain/Entities/Character.cs

using RickAndMortyAPI.Domain.Entities;

namespace RickAndMortyAPI.Domain.Entities
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Species { get; set; }
        public string? Type { get; set; }
        public string Gender { get; set; }
        public Origin Origin { get; set; } // Updated to use Origin entity
        public Location Location { get; set; } // Updated to use Location entity
        public string Image { get; set; }
        public ICollection<Episode> Episodes { get; set; }

        public List<EpisodeCharacter> EpisodeCharacters { get; set; } = new List<EpisodeCharacter>();

    }
}
