using System.Collections.Generic;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Building> buildings { get; set; }
        public DbSet<ResidentialBuilding> resBuils { get; set; }
        public DbSet<Worker> workers { get; set; }
        public DbSet<Material> materials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка таблиц
            modelBuilder.Entity<Building>().ToTable("buildings");
            modelBuilder.Entity<ResidentialBuilding>().ToTable("buildings");
            modelBuilder.Entity<Worker>().ToTable("workers");
            modelBuilder.Entity<Material>().ToTable("materials");

            // Настройка наследования
            modelBuilder.Entity<Building>()
                .HasDiscriminator<string>("BuildingType")           // имя столбца в БД
                .HasValue<Building>("Commercial")                   // значение для обычного здания
                .HasValue<ResidentialBuilding>("Residential");      // значение для жилого

            // Связь Worker -> Building
            modelBuilder.Entity<Worker>()
                .HasOne(w => w.Building)
                .WithMany()               // один Building может иметь много Worker
                .HasForeignKey(w => w.BuildingId);
        }
    }
}