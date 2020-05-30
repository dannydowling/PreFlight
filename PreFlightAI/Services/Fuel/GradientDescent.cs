﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;
using PreFlightAI.Server.Services;
using PreFlightAI.Shared;
using PreFlightAI.Shared.Places;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PreFlight.AI.Server.Services
{
    public class GradientDescent
    {

        private readonly WeatherDataService weatherDataService;
        private readonly FuelDensity fuelDensity;
        private readonly IEnumerable<Weather> forecast;

        public GradientDescent()
        {
            
            forecast = weatherDataService.GetAllWeatherForDensity().Result;
        }
        public async Task fetchWeather(int weatherId)
        {
            await weatherDataService.GetWeatherDetails(weatherId);
        }

        public double predictDensity(Weather weather)
        {

            forecast.ToList();            

            Weather closest = forecast.Aggregate((x, y) => 
            Math.Abs(x.Temperature - weather.Temperature) < Math.Abs(y.AirPressure - weather.AirPressure) ? x : y);

            return fuelDensity.CurrentFuelDensity(closest);            
          
            }
        }
    }

