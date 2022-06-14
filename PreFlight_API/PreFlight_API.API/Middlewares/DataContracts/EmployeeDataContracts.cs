using System;

namespace PreFlight_API.API.Middlewares.DataContracts
{
    public class RegisterEmployeeRequest : EmployeeDto
    {
        // what information will we provide/require whenever one of these requests comes in.
    }

    public class EmployeeDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string JobCategory { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public LocationDto[] Addresses { get; set; }
        public string Password { get; set; }
    }
    public class RegisterEmployeeResponse
    {
        public long Id { get; set; }
    }

    public class EditEmployeeInfoRequest
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

    public class GetEmployeeResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set;}
        public LocationDto[] Addresses { get; set; }
        public RoleEnrollmentDto[] Enrollments { get; set; }
    }
}
