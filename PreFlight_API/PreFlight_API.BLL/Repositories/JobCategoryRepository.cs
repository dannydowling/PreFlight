using PreFlight.AI.Server.Services.SQL;
using PreFlight.AI.Shared.Policies;
using PreFlight.Infrastructure.Repositories;
using PreFlightAI.Shared.Employee;
using PreFlightAI.Shared.Employee.Ghosts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PreFlight.Infrastructure.Repositories
{
    public class JobCategoryRepository : GenericRepository<Employee>
    {
        public JobCategoryRepository(ServerDbContext context) : base(context)
        {
        }

        public override Employee Get(Guid role)
        {
            var jobCategoryId = context.Employees
                .Where(c => c.JobCategoryId == role)
                .Select(c => c.JobCategoryId)
                .Single();

            return new GhostEmployee(() => base.Get(role))
            {
                JobCategoryId = jobCategoryId
            };
        }

        public IEnumerable<Employee> All(Guid role)
        {
            return context.Set<Employee>()
                .AsQueryable()
                .ToList()
                .Where(c => c.JobCategoryId == role);
        }
       
               
        public void Delete(JobCategory entity)
        {
            var role = context.JobCategories
                        .Single(c => c.JobCategoryId == entity.JobCategoryId);

            context.Remove(role);
            context.SaveChanges();

        }
    }
}
