using System;

namespace PreFlight_API.API.Middlewares.DataContracts
{
    public class RegisterRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string JobCategory { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public LocationDto[] Addresses { get; set; }

        public string Password { get; set; }
    }

    public class EmployeeDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public LocationDto[] Addresses { get; set; }
    }

    public class LocationDto
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }

    public class RegisterResponse
    {
        public long Id { get; set; }
    }

    public class EditPersonalInfoRequest
    {
        public string Name { get; set; }
        public LocationDto[] Addresses { get; set; }
    }

    public class JobRoleRequest
    {
        public RoleEnrollmentDto[] Enrollments { get; set; }
    }

    public class RoleEnrollmentDto
    {
        public string JobCategory { get; set; }
    }

    public class GetResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public LocationDto[] Addresses { get; set; }
        public RoleEnrollmentDto[] Enrollments { get; set; }
    }
}


// employee
// user
// weather
// location
// role
// order
// product