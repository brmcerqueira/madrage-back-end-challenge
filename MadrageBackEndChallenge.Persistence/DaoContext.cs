using MadrageBackEndChallenge.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace MadrageBackEndChallenge.Persistence
{
    public sealed class DaoContext : DbContext
    {
        public DaoContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new MenuConfiguration());
            modelBuilder.ApplyConfiguration(new MenuUserConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}