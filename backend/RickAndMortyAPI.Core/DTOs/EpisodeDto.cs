// RickAndMortyAPI.Core/DTOs/EpisodeDto.cs
namespace RickAndMortyAPI.Core.DTOs
{
    public class EpisodeDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? AirDate { get; set; }
    public string Episode { get; set; }
    public List<string> Characters { get; set; }
}

}
