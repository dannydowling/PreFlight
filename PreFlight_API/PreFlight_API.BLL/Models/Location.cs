using PreFlight_API.BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PreFlight_API.BLL.Models
{
    public class Location
    {
       
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public CountryEnum Country { get; set; }

        public ICollection<Employee> Employees { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

    }

    public enum CountryEnum
    {
        America = 0
    }
}
