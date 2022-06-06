using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PreFlight_API.BLL;
using PreFlight_API.BLL.Models;
using PreFlight_API.DAL.MySql;
using PreFlight_API.DAL.MySql.Contract;
using PreFlightAI.Server.Services;
using System;
using System.Linq;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class WebServiceExtensions
    {
        public static IServiceCollection AddWebServices(
            this IServiceCollection services,
            IConfigurationSection BLLOptionsSection,
            IConfigurationSection DALOptionSection)
        {
            if (BLLOptionsSection == null)
            {
                throw new ArgumentNullException(nameof(BLLOptionsSection));
            }

            if (DALOptionSection == null)
            {
                throw new ArgumentNullException(nameof(DALOptionSection));
            }

            var bllSettings = new PreFlightBLLOptions();

            services.Configure<PreFlightBLLOptions>(opt =>
            {
                opt.JwtSecretKey = bllSettings.JwtSecretKey;
                opt.WebApiUrl = bllSettings.WebApiUrl;
            });
            services.Configure<PreFlightMySqlRepositoryOption>(opt =>
            {
                 opt.UserDbConnectionString = DALOptionSection.GetConnectionString("UserDbConnectionString");
                 opt.WeatherDbConnectionString = DALOptionSection.GetConnectionString("WeatherDbConnectionString");
                 opt.EmployeeDbConnectionString = DALOptionSection.GetConnectionString("EmployeeDbConnectionString");
                 opt.LocationDbConnectionString = DALOptionSection.GetConnectionString("LocationDbConnectionString");

            });

            services.TryAddSingleton<IUserRepository, UserRepository>();
            services.TryAddSingleton<IEmployeeRepository, EmployeeRepository>();
            services.TryAddSingleton<IWeatherRepository, WeatherRepository>();
            services.TryAddSingleton<ILocationRepository, LocationRepository>();

            services.TryAddScoped<IUserService, UserService>();
            services.TryAddScoped<IEmployeeService, EmployeeService>();
            services.TryAddScoped<IJobCategoryService, JobCategoryService>();
            services.TryAddScoped<ILocationService, LocationService>();
            services.TryAddScoped<IWeatherService, WeatherService>();
            services.TryAddScoped<IJwtTokenService, JwtTokenService>();

        
            services.AddHealthChecks()
                .AddCheck<UserRepository>("UserRepository")
                .AddCheck<EmployeeRepository>("EmployeeRepository")
                .AddCheck<WeatherRepository>("WeatherRepository")
                .AddCheck<LocationRepository>("LocationRepository");

            return services;
        }

        public static IApplicationBuilder UseWebServices(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/api/health", new HealthCheckOptions()
            {
                ResponseWriter = (httpContext, result) =>
                {
                    httpContext.Response.ContentType = "application/json";

                    var json = new JObject(
                        new JProperty("status", result.Status.ToString()),
                        new JProperty("results", new JObject(result.Entries.Select(pair =>
                            new JProperty(pair.Key, new JObject(
                                new JProperty("status", pair.Value.Status.ToString())))))));
                    return httpContext.Response.WriteAsync(
                        json.ToString(Formatting.Indented));
                }
            });

            return app;
        }
    }
}
