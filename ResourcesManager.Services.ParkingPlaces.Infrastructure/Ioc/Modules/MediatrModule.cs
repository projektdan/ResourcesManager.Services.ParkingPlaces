using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Ioc.Modules
{
    public class MediatrModule : IModule
    {
        public void Load(IServiceCollection services)
        {
            var assembly = typeof(MediatrModule).Assembly;
            services.AddMediatR(assembly);
        }
    }
}
