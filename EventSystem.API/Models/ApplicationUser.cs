namespace EventSystem.API.Models;

public class ApplicationUser: IdentityUser
{
    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
