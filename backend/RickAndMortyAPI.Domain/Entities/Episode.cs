using RickAndMortyAPI.Domain.Entities;

namespace RickAndMortyAPI.Domain.Entities{
public class Episode
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? AirDate { get; set; }
    public string EpisodeCode { get; set; }

    public virtual ICollection<EpisodeCharacter> EpisodeCharacters { get; set; }
}
}
