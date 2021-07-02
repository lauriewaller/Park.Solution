using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ParkApi.Models
{
  public class ParkApiContext : DbContext
  {
    public ParkApiContext(DbContextOptions<ParkApiContext> options)
        : base(options)
    {
    }

    public DbSet<Park> Parks { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Park>() 
          .HasData( 
              new Park { ParkId = 1, Name = "Glacier National Park", ParkType = "National", Location = "Montana" },
              new Park { ParkId = 2, Name = "Death Valley National Park", ParkType = "National", Location = "California" },
              new Park { ParkId = 3, Name = "Olympic National Park", ParkType = "National", Location = "Washington" },
              new Park { ParkId = 4, Name = "North Cascades National Park", ParkType = "National", Location = "Washington" },
              new Park { ParkId = 5, Name = "Sequoia National Park", ParkType = "National", Location = "California" },
              new Park { ParkId = 6, Name = "Milo McIver State Park", ParkType = "State", Location = "Oregon" },
              new Park { ParkId = 7, Name = "Silver Falls Park", ParkType = "State", Location = "Oregon" }
          );
    }
  }
}