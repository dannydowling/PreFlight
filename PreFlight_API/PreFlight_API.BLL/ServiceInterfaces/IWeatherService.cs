using PreFlight_API.BLL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreFlight_API.BLL
{
    public interface IWeatherService
    {
        Task<IEnumerable<Weather>> GetWeatherListAsync(int pageNumber, int pageSize, double? AirPressure, double? Temperature);
        Task<Weather> GetWeatherById(Guid Id);
        Task<IEnumerable<Weather>> GetWeatherByAirPressureAsync(double AirPressure);

        Task<IEnumerable<Weather>> GetWeatherByTemperatureAsync(double Temperature);
        Task<Weather> CreateWeatherAsync(Weather weather);
        Task UpdateWeather(Weather weather);
        Task DeleteWeather(Guid id);
    }
}
