using Microsoft.EntityFrameworkCore;
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
                .Include(weather => weather)
                .Where(predicate).ToList();
        }
        public override Weather Update(Weather entity)
        {

            var weather = context.Weathers.Where(a => a.Id == entity.Id);
            foreach (var item in weather)
            {
                base.Update(item);
            }

            return weather.FirstOrDefault();
        }

        private long _lastId()
        {
           var weather = context.Weathers.Where(x => x.Id == x.Id).Max();
            return weather.Id;
          
        }


        public Weather getById(long id)
        {
            return Find(x => x.Id == id).SingleOrDefault();
        }

        public List<Weather> getByTemperature(double Temperature)
        {
            return Find(x => x.Temperature == Temperature).ToList();
        }

        public List<Weather> getByAirPressure(double AirPressure)
        {
            return Find(x => x.AirPressure == AirPressure).ToList();
        }

        private static void SetId(Entity entity, long id)
        {
            entity.GetType().GetProperty(nameof(Entity.Id)).SetValue(entity, id);
        }

        public void Save(Weather weather)
        {
            
            if (weather.Id == 0)
            {
                var lastId = _lastId();
                SetId(weather, lastId++);
            }

            // Saving to the database
           var old_Weather_Info = context.Find<Weather>(weather.Id);
            context.Remove(old_Weather_Info);
            
            context.Add(weather);
            context.SaveChanges();
        }
    }
}
