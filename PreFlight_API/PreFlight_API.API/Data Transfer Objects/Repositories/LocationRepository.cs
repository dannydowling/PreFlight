using PreFlight.Infrastructure.Repositories;
using PreFlight_API.BLL.Contexts;
using PreFlight_API.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PreFlight.Infrastructure.Repositories
{
    public class LocationRepository : GenericRepository<Location>
    {
        public LocationRepository(GeneralDbContext context) : base(context)
        {
        }

        public override Location Get(Guid id)
        {
            var locationId = context.Locations
                .Where(c => c.LocationId == id)
                .Select(c => c.LocationId)
                .Single();

            return new GhostLocation(() => base.Get(id))
            {
                LocationId = locationId
            };
        }

        public double GetLatitudeFor(string lookup)
        {

            //lazily load up the latitude when asked for it.
            var latitude = context.Locations
                .Where(c => c.State + " " + c.Street == lookup)
                .Select(c => c.Latitude)
                .Single();

            return latitude;
        }

        public double GetLongtitudeFor(string lookup)
        {

            //lazily load up the longitude when asked for it.
            var longitude = context.Locations
                .Where(c => c.State + " " + c.Street == lookup)
                .Select(c => c.Longitude)
                .Single();

            return longitude;
        }

        public override IEnumerable<Location> All()
        {
            return base.All();
        }

        public override Location Add (Location entity)
        {
            context.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public override Location Update(Location entity)
        {
            var location = context.Locations
                .Single(c => c.LocationId == entity.LocationId);

           location.Street  = location.Street;
           location.City    = location.City;
           location.State   = location.State;
           location.ZipCode = location.ZipCode;
           location.Latitude = location.Latitude;
           location.Longitude = location.Longitude;
           

            return base.Update(location);
           
        }
               
        public override void Delete(Location entity)
        {
            var location = context.Locations
                        .Single(c => c.LocationId == entity.LocationId);

            context.Remove(location);
            context.SaveChanges();

        }

        public class StateRepositoryDTO
        {
            public string[] GetAll()
            {
                return new[] { "VA", "DC" };
            }
        }

        public class CountryRepositoryDTO
        {
            public string[] GetAll()
            {
                return new[] { "VA", "DC" };
            }
        }
    }
}
