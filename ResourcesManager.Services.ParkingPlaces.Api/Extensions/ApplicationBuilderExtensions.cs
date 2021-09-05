using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Services.Interfaces;
using System;
using System.Linq;

namespace ResourcesManager.Services.ParkingPlaces.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigration<TContext>(this IApplicationBuilder app)
            where TContext : DbContext
        {
            var context = app.ApplicationServices.GetService<TContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                Console.WriteLine($"Migrating {typeof(TContext).Name}...");
                context.Database.Migrate();
                Console.WriteLine($"Migration of {typeof(TContext).Name} done.");
            }
        }

        public static IApplicationBuilder UseSeed(this IApplicationBuilder app)
        {
            var seeder = app.ApplicationServices.GetService<ISeeder>();
            var seedTask = seeder.SeedAsync();
            seedTask.Wait();

            return app;
        }
    }
}
