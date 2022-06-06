using PreFlight.AI.Server.Services.SQL;
using PreFlight.Infrastructure.Repositories;
using PreFlightAI.Shared.Employee;
using PreFlightAI.Shared.Employee.Ghosts;
using PreFlightAI.Shared.Places;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PreFlight.Infrastructure.Repositories
{
    public class LocationRepository : GenericRepository<Location>
    {
        public LocationRepository(ServerDbContext context) : base(context)
        {
        }

        public override Location Get(Guid id)
        {
            var employeeId = context.Employees
                .Where(c => c.LocationId == id)
                .Select(c => c.LocationId)
                .Single();

            return new GhostEmployee(() => base.Get(id))
            {
                LocationId = locationId
            };
        }

        public byte[] GetProfilePictureFor(string lookup)
        {

            //lazily load up the profile picture when asked for it.
            var profilePicture = context.Employees
                .Where(c => c.FirstName + " " + c.LastName == lookup)
                .Select(c => c.ProfilePicture)
                .Single();

            return profilePicture;
        }

        public override IEnumerable<Employee> All()
        {
            return base.All();
        }

        public override Employee Add (Employee entity)
        {
            context.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public override Employee Update(Employee entity)
        {
            var employee = context.Employees
                .Single(c => c.EmployeeId == entity.EmployeeId);

            employee.LocationId = employee.LocationId;
            employee.BirthDate = employee.BirthDate;
            employee.City = employee.City;
            employee.Email = employee.Email;
            employee.FirstName = employee.FirstName;
            employee.LastName = employee.LastName;
            employee.PhoneNumber = employee.PhoneNumber;
            employee.Street = employee.Street;
            employee.Zip = employee.Zip;
            employee.JobCategoryId = employee.JobCategoryId;
            employee.Comment = employee.Comment;
            employee.ExitDate = employee.ExitDate;
            employee.JoinedDate = employee.JoinedDate;
            employee.Password = employee.Password;

            return base.Update(employee);
           
        }
               
        public override void Delete(Employee entity)
        {
            var employee = context.Employees
                        .Single(c => c.EmployeeId == entity.EmployeeId);

            context.Remove(employee);
            context.SaveChanges();

        }
    }
}
