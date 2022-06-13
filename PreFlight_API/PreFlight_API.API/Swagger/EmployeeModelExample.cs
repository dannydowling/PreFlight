using PreFlight_API.BLL.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
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
                JobCategory = "Owner",
                PhoneNumber = "9073213215",
                Locations = DannyAddress() ,
                Password = "Password",
                JoinedDate = dnow
            }; 
        }

            private ICollection<Location> DannyAddress()
            {
            var addresses = new List<Location>();   

            var address = Location.Create("1234 Main St", "Juneau", "AK", "99801", 58.1, 57.6, new[] { "AK" });

            addresses.Add(address.Value);
            return addresses;
                
            }
        }
    }

