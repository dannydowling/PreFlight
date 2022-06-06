using PreFlight.AI.Server.Services.SQL;
using PreFlight.Infrastructure.Repositories;
using PreFlightAI.Shared.Employee;
using PreFlightAI.Shared.Employee.Ghosts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PreFlight.Infrastructure.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>
    {
        public EmployeeRepository(ServerDbContext context) : base(context)
        {
        }

        public override Employee Get(Guid id)
        {
            var employeeId = context.Employees
                .Where(c => c.EmployeeId == id)
                .Select(c => c.EmployeeId)
                .Single();

            return new GhostEmployee(() => base.Get(id))
            {
                EmployeeId = employeeId
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
