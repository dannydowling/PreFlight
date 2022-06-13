using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PreFlight_API.BLL.Models
{
    public class Weather : Entity
    {
       
        public long Id { get; set; }
        public double AirPressure { get; set; }
        public double Temperature { get; set; }
        public double WeightValue { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}    
