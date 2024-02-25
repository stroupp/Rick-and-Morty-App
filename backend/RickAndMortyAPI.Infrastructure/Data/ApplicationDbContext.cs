using Microsoft.EntityFrameworkCore;
using RickAndMortyAPI.Domain.Entities;

namespace RickAndMortyAPI.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<EpisodeCharacter> EpisodeCharacters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EpisodeCharacter>()
                .HasKey(ec => new { ec.EpisodeId, ec.CharacterId });

            modelBuilder.Entity<EpisodeCharacter>()
                .HasOne(ec => ec.Episode)
                .WithMany(e => e.EpisodeCharacters)
                .HasForeignKey(ec => ec.EpisodeId);

            modelBuilder.Entity<EpisodeCharacter>()
                .HasOne(ec => ec.Character)
                .WithMany(c => c.EpisodeCharacters)
                .HasForeignKey(ec => ec.CharacterId);
        }
    }
}
