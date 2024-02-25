// RickAndMortyAPI.Core/DTOs/CharacterDto.cs
namespace RickAndMortyAPI.Core.DTOs
{
    public class CharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Species { get; set; }
        public string Gender { get; set; }

        public string Type { get; set; }
        public OriginDto Origin { get; set; }
        public LocationDto Location { get; set; }
        public string Image { get; set; }
        public List<string> Episode { get; set; }
    }

    public class OriginDto
    {
        public string Name { get; set; }
    }

    public class LocationDto
    {
        public string Name { get; set; }
    }
}
