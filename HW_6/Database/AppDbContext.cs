using HW_6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HW_6.Database
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext(){}

        public DbSet<Group> Groups { get; set; }

        public DbSet<Analysis> Analysis { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("dbsettings.json")
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Order>()
                .HasOne(o => o.OrdAnalysis)
                .WithMany(a => a.Orders)
                .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}