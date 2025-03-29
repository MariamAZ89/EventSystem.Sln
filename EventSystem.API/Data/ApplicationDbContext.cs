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
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Event>()
            .HasOne(e => e.Artist)
            .WithMany(a => a.Events)
            .HasForeignKey(e => e.ArtistId);

        builder.Entity<Ticket>()
            .HasOne(t => t.Event)
            .WithMany(e => e.Tickets)
            .HasForeignKey(t => t.EventId);

        builder.Entity<Ticket>()
            .HasOne(t => t.User)
            .WithMany(u => u.Tickets)
            .HasForeignKey(t => t.UserId);


        builder.Entity<Artist>().HasData(new Artist
        {
            ArtistId = 1,
            Name = "The Beatles",
            Genre = "Rock",
            Biography = "The Beatles were an English rock band formed in Liverpool in 1960. With a line-up comprising John Lennon, Paul McCartney, George Harrison and Ringo Starr, they are regarded as the most influential band of all time."
        }, 
        new Artist
        {
            ArtistId = 2,
            Name = "Queen",
            Genre = "Rock",
            Biography = "Queen are a British rock band formed in London in 1970. Their classic line-up was Freddie Mercury (lead vocals, piano), Brian May (guitar, vocals), Roger Taylor (drums, vocals) and John Deacon (bass)."
        });
    }
}
