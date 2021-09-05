using Microsoft.Extensions.DependencyInjection;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Services;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Ioc.Modules
{
    public class ServiceModule : IModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddTransient<ISeeder, Seeder>();
            services.AddTransient<IUnitOfWorkFactory, UnitOfWorkFactory>();
        }
    }
}
