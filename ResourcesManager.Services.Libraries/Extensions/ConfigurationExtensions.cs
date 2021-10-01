using Microsoft.Extensions.Configuration;

namespace ResourcesManager.Services.Libraries.Extensions
{
    public static class ConfigurationExtensions
    {
        public static TOptions GetOptions<TOptions>(this IConfiguration configuration, string section)
            where TOptions : new()
        {
            var cfg = new TOptions();
            configuration.Bind(section, cfg);
            return cfg;
        }
    }
}
