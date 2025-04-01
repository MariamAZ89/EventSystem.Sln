using EventSystem.API.Dtos.TicketDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EventSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TicketsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TicketsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (User.IsInRole("Administrator"))
        {
            return Ok(await _context.Tickets.Include(t => t.Event).ThenInclude(e => e.Artist).ToListAsync());
        }
        return Ok(await _context.Tickets
            .Where(t => t.UserId == userId)
            .Include(t => t.Event).ThenInclude(e => e.Artist)
            .ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> PurchaseTickets([FromBody] TicketPurchaseDto dto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null) return Unauthorized();

        var eventEntity = await _context.Events.FindAsync(dto.EventId);
        if (eventEntity == null) return NotFound("Event not found");

        var tickets = Enumerable.Range(0, dto.Quantity).Select(_ => new Ticket
        {
            EventId = dto.EventId,
            UserId = userId,
            PurchaseDate = DateTime.UtcNow
        }).ToList();

        _context.Tickets.AddRange(tickets);
        await _context.SaveChangesAsync();
        return Ok(new { Message = $"{dto.Quantity} ticket(s) purchased successfully" });
    }
}
