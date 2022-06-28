
using PreFlight.Infrastructure.Repositories;
using PreFlight_API.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PreFlightAI.Shared.Customers.Proxies
{
    public class LocationProxy : Location
    {

        LocationRepository locationRepository;

        public override double Latitude
        {
            get
            {
                if (base.Latitude == null)
                {
                    base.Latitude = locationRepository.GetLatitudeFor(State + " " + Street);
                }

                return base.Latitude;
            }
        }

        public override double Longitude
        {
            get
            {
                if (base.Longitude == null)
                {
                    base.Longitude = locationRepository.GetLongitudeFor(State + " " + Street);
                }

                return base.Longitude;
            }
        }
    }
}
