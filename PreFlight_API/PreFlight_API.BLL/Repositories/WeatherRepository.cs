using Microsoft.EntityFrameworkCore;
using PreFlight.Infrastructure.Repositories;
using PreFlight_API.BLL.Contexts;
using PreFlight_API.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PreFlight.Infrastructure.Repositories
{
    public class WeatherRepository : GenericRepository<Weather>
    {
        public WeatherRepository(GeneralDbContext context) : base(context)
        {

        }

        public override IEnumerable<Weather> Find(Expression<Func<Weather, bool>> predicate)
        {
            return context.Weathers
                .Include(weather => weather.DensityTotal)
                .Where(predicate).ToList();
        }
        public override Weather Update(Weather entity)
        {

            var weather = context.Weathers.Where(a => a.WeatherItems == entity.WeatherItems);
            foreach (var item in weather)
            {
                base.Update(item);
            }

            return weather.FirstOrDefault();
        }
    }
}
