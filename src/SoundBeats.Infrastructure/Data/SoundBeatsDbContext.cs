using Microsoft.EntityFrameworkCore;
using SoundBeats.Core.Domain;

namespace SoundBeats.Infrastructure.Data
{
    public class SoundBeatsDbContext : DbContext
    {
        public SoundBeatsDbContext(DbContextOptions<SoundBeatsDbContext> options) : base(options)
        {

        }

        public DbSet<Country> Country { get; set; }
        
        public DbSet<Artist> Artist { get; set; }
        
        public DbSet<Album> Album { get; set; }

        public DbSet<Genre> Genre { get; set; }

        public DbSet<Song> Song { get; set; }

        public DbSet<Musician> Musician { get; set; }

        public DbSet<GroupMember> GroupMember { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SoundBeatsConfiguration());
        }
    }
}
