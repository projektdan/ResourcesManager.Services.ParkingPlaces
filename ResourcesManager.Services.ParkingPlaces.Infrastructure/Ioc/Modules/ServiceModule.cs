using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Services;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Services.Interfaces;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Ioc.Modules
{
    public class ServiceModule : IModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddTransient<ISeeder, Seeder>();
            services.AddTransient<IUnitOfWorkFactory, UnitOfWorkFactory>();
            services.AddTransient<IResourceService, ResourceService>();
            services.AddTransient<ILocationService, LocationService>();

            //services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
        }
    }
}
