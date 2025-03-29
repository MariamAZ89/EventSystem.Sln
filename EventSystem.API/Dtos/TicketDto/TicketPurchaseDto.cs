namespace EventSystem.API.Dtos.TicketDto;

public class TicketPurchaseDto
{
    public int EventId { get; set; }
    public int Quantity { get; set; } = 1;
}
