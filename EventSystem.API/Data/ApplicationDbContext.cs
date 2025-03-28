using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventSystem.API.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Event> Events { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Event>()
            .HasOne(e => e.Artist)
            .WithMany(a => a.Events)
            .HasForeignKey(e => e.ArtistId);

        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.Event)
            .WithMany(e => e.Tickets)
            .HasForeignKey(t => t.EventId);

        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.User)
            .WithMany(u => u.Tickets)
            .HasForeignKey(t => t.UserId);

        modelBuilder.Entity<Event>().Navigation(b => b.Artist);
        modelBuilder.Entity<Event>().Navigation(b => b.Tickets);

        modelBuilder.Entity<Ticket>().Navigation(b => b.User);
        modelBuilder.Entity<Ticket>().Navigation(b => b.Event);

        modelBuilder.Entity<Artist>().Navigation(b => b.Events);
    }
}
