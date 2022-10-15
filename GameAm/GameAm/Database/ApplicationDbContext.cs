using GameAm.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameAm.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<WebPoint> WebPoints { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            GenerateAdminAndRoles(modelBuilder);
        }

        private void GenerateAdminAndRoles(ModelBuilder builder)
        {
        }
    }
}
