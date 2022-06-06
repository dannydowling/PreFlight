using PreFlight_API.BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PreFlight_API.BLL.Models
{
    public class Location
    {
        [Key]
        public Guid LocationId { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public CountryEnum Country { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

    }

    public class Coordinates
    {
        [ForeignKey("LocationId")]
        public int LocationId { get; set; }

        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public Coordinates(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }

    public enum CountryEnum
    {
        America = 0
    }

    public enum LocationName
    {
        Juneau = 0,
        Sitka = 1
    }
}
