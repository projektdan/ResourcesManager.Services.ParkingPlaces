using Microsoft.EntityFrameworkCore;
using ResourcesManager.Services.Libraries.Options;
using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Database.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        private readonly DatabaseOptions databaseOptions;

        internal DbSet<Location> Locations { get; set; }
        internal DbSet<Reservation> Reservations { get; set; }
        internal DbSet<Resource> Resources { get; set; }
        internal DbSet<User> Users { get; set; }
        internal DbSet<ReservationState> ReservationStates { get; set; }

        public AppDbContext(DatabaseOptions databaseOptions)
        {
            this.databaseOptions = databaseOptions;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbOptionsBuilder)
        {
            dbOptionsBuilder.UseNpgsql(this.databaseOptions.ConnectionString, options =>
            {
                options.MigrationsHistoryTable("__EFMigrationsHistory", this.databaseOptions.Schema);
                options.MigrationsAssembly("ResourcesManager.Services.ParkingPlaces.Api");
            });

            base.OnConfiguring(dbOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(this.databaseOptions.Schema);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            modelBuilder.HasPostgresExtension("uuid-ossp");

        }
    }
}
