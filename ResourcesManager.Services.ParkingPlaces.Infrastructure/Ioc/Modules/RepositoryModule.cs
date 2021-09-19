using Microsoft.Extensions.DependencyInjection;
using ResourcesManager.Services.ParkingPlaces.Core.Repositories;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Repositories;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Ioc.Modules
{
    public class RepositoryModule : IModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<IReservationRepository, ReservationRepository>();
            services.AddTransient<IResourceRepository, ResourceRepository>();
            services.AddTransient<IReservationStateRepository, ReservationStateRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
