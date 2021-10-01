using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ResourcesManager.Services.Libraries.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterOptions<TOptions>(this IServiceCollection services, string section)
            where TOptions : class, new()
        {
            using (var sp = services.BuildServiceProvider())
            {
                var cfg = sp.GetService<IConfiguration>();
                var options = cfg.GetOptions<TOptions>(section);
                services.AddSingleton(options);
            }

            return services;
        }
    }
}
