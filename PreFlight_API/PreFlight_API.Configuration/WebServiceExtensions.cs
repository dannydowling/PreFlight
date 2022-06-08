using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PreFlight.Infrastructure.Repositories;
using PreFlight_API.BLL;
using PreFlight_API.BLL.Contexts;
using PreFlight_API.BLL.Models;
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
            services.AddDbContext<GeneralDbContext>(
             options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

            services.TryAddScoped<IJwtTokenService, JwtTokenService>();



            return services;
        }
    }
}
