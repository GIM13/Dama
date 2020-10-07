using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class Context : DbContext
    {
        public DbSet<Pawn> Pawns { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Playground> Playgrounds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().HasKey(ps => new { ps.Id, ps.Name }); 
        }
    }
}
