namespace EventSystem.API.Models;

public class Ticket
{
    [Key]
    public int TicketId { get; set; }
    public int EventId { get; set; }
    public Event Event { get; set; } = null!;
    public string UserId { get; set; } = string.Empty;
    public ApplicationUser User { get; set; } = null!;
    public DateTime PurchaseDate { get; set; }
}
