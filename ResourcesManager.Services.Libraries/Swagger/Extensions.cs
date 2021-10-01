using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using ResourcesManager.Services.Libraries.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ResourcesManager.Services.Libraries.Swagger
{
    public static class Extensions
    {
        public static IServiceCollection AddSwaggerDocs(this IServiceCollection services)
        {
            var section = "swagger";
            var options = services.GetOptions<SwaggerOptions>(section);
            services.RegisterOptions<SwaggerOptions>(section);

            if (!options.Enabled)
            {
                return services;
            }

            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(options.Name, new OpenApiInfo { Title = options.Title, Version = options.Title });
                if (options.IncludeXmlComments)
                {
                    List<string> assembliesNames = new();
                    assembliesNames.Add(Assembly.GetEntryAssembly().GetName().Name);
                    assembliesNames.AddRange(Assembly.GetEntryAssembly()
                        .GetReferencedAssemblies()
                        .Where(x => x.Name.Contains("Services"))
                        .Select(x => x.Name));

                    foreach (var assemblyName in assembliesNames.Distinct())
                    {
                        var xmlFile = $"{assemblyName}.xml";
                        var xmlPath = ConfigurationPath.Combine(AppContext.BaseDirectory, xmlFile);
                        if (File.Exists(xmlPath))
                        {
                            c.IncludeXmlComments(xmlPath);
                        }
                    }
                }

            });
        }

        public static IApplicationBuilder UseSwaggerDocs(this IApplicationBuilder builder)
        {
            var options = builder.ApplicationServices.GetService<SwaggerOptions>();

            if (!options.Enabled)
            {
                return builder;
            }

            var routePrefix = string.IsNullOrWhiteSpace(options.RoutePrefix) ? "swagger" : options.RoutePrefix;

            builder.UseStaticFiles()
                .UseSwagger(c => c.RouteTemplate = routePrefix + "/{documentName}/swagger.json");

            return options.ReDocEnabled ? builder.UseReDoc(c =>
            {
                c.RoutePrefix = routePrefix;
                c.SpecUrl = $"{options.Name}/swagger.json";
            }) : builder.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/{routePrefix}/{options.Name}/swagger.json", options.Title);
                c.RoutePrefix = routePrefix;
            });
        }

        public static IConfiguration GetConfigurationService(this IServiceCollection services)
        {
            using (var serviceProvider = services.BuildServiceProvider())
            {
                return serviceProvider.GetService<IConfiguration>();
            }
        }

        public static TOptions GetOptions<TOptions>(this IServiceCollection services, string section)
            where TOptions : class, new()
        {
            var cfgService = services.GetConfigurationService();
            return cfgService.GetOptions<TOptions>(section);
        }
    }
}
