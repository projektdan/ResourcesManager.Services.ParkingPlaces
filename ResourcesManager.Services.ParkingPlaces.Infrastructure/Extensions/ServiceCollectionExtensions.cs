using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterExternalModules(this IServiceCollection services)
        {
            var assemblyTypes = Assembly.GetExecutingAssembly();

            var iocModule = assemblyTypes
            .ExportedTypes
            .Where(t => typeof(IModule).IsAssignableFrom(t)
                                        && !t.IsInterface
                                        && !t.IsAbstract)
            .Select(Activator.CreateInstance)
            .Cast<IModule>()
            .ToList();

            iocModule.ForEach(module => module.Load(services));
        }

        public static IServiceCollection RegisterOptions<TOptions>(this IServiceCollection serviceCollection, string section)
            where TOptions : class, new()
        {
            using (var serviceProvider = serviceCollection.BuildServiceProvider())
            {
                var configuration = serviceProvider.GetService<IConfiguration>();
                var options = configuration.GetOptions<TOptions>(section);
                serviceCollection.AddSingleton(options);
            }

            return serviceCollection;
        }
    }
}
