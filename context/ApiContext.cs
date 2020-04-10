
using Microsoft.EntityFrameworkCore;

namespace Elevators_API.Contexts 
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }
        // Tables
        public DbSet<Intervention> Interventions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Intervention>()
                .ToTable("interventions")
                .HasKey(x => x.id);

        }
    }
}