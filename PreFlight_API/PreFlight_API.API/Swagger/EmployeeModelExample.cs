using PreFlight_API.BLL.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.ComponentModel.DataAnnotations;

namespace PreFlight_API.API.Swagger
{
    public class EmployeeModelExample : IExamplesProvider<Employee>
    {
        public Employee GetExamples()
        {
            var dnow = DateTime.UtcNow;
            return new Employee
            {
                EmployeeId = Guid.NewGuid(),
                Email = "KauraiRentals@gmail.com",
                FirstName = "Danny",
                LastName = "Dowling",
                BirthDate = dnow,
                JobCategoryId = 1,
                PhoneNumber = "9073213215",
                Locations = { "Juneau", "Sitka"},
                employeeWeatherList = { },
                Password = "Password",
                JoinedDate = dnow               
            };
        }
    }
}
