namespace EventSystem.API.Models;

public class Artist
{
    [Key]
    public int ArtistId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public string Biography { get; set; } = string.Empty;
    public ICollection<Event> Events { get; set; } = new List<Event>();
}
