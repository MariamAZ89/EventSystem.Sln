namespace EventSystem.API.Dtos.EvenntsDto;

public class CreateEventDto
{
    public string Title { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string Location { get; set; } = string.Empty;
    public int ArtistId { get; set; }
}
