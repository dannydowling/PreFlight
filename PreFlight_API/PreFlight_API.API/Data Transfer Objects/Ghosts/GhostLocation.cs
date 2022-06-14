
using PreFlightAI.Shared.Customers.Proxies;
using System;

namespace PreFlight_API.BLL.Models
{
    public class GhostLocation : LocationProxy
    {
        private LoadStatus status;
        private readonly Func<Location> load;

        public bool IsGhost => status == LoadStatus.GHOST;
        public bool IsLoaded => status == LoadStatus.LOADED;

        public GhostLocation(Func<Location> load) : base()
        {
            this.load = load;
            status = LoadStatus.GHOST;
        }

        public override string Street
        {
            get
            {
                Load();

                return base.Street;
            }
            set
            {
                Load();

                base.Street = value;
            }
        }

        public override string City
        {
            get
            {
                Load();

                return base.City;
            }
            set
            {
                Load();

                base.City = value;
            }
        }

        public override State State
        {
            get
            {
                Load();

                return base.State;
            }
            set
            {
                Load();

                base.State = value;
            }
        }

        public override string ZipCode
        {
            get
            {
                Load();

                return base.ZipCode;
            }
            set
            {
                Load();

                base.ZipCode = value;
            }
        }

        public override double Latitude
        {
            get
            {
                Load();

                return base.Latitude;
            }
            set
            {
                Load();

                base.Latitude = value;
            }
        }

        public override double Longitude
        {
            get
            {
                Load();

                return base.Longitude;
            }
            set
            {
                Load();

                base.Longitude = value;
            }
        }


        public void Load()
        {
            if (IsGhost)
            {
                status = LoadStatus.LOADING;

                var location = load();
                base.Street = location.Street;
                base.City = location.City;
                base.State = location.State;
                base.ZipCode = location.ZipCode;
                base.Latitude = location.Latitude;
                base.Longitude = location.Longitude;                

                status = LoadStatus.LOADED;
            }
        }
    }

}
