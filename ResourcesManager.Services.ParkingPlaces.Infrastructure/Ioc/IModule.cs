using Microsoft.Extensions.DependencyInjection;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Ioc
{
    public interface IModule
    {
        void Load(IServiceCollection services);
    }
}
