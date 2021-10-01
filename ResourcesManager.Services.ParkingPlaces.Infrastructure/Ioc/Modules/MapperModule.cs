using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Mapper;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Ioc.Modules
{
    public class MapperModule : IModule
    {
        public void Load(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
