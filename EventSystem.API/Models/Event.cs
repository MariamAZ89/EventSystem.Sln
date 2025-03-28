namespace EventSystem.API.Models;

public class Event
{
    [Key]
    public int EventId { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string Location { get; set; } = string.Empty;
    public int ArtistId { get; set; }
    public Artist Artist { get; set; } = null!;
    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
