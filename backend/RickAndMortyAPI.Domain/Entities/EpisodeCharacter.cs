namespace RickAndMortyAPI.Domain.Entities{
public class EpisodeCharacter
{
    public int EpisodeId { get; set; }
    public virtual Episode Episode { get; set; }

    public int CharacterId { get; set; }
    public virtual Character Character { get; set; }
}


}
