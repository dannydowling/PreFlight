using PreFlight.Infrastructure.Repositories;
using PreFlight_API.BLL.Contexts;
using PreFlight_API.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PreFlight.Infrastructure.Repositories
{
    public class JobCategoryRepository : GenericRepository<Employee>
    {
        public JobCategoryRepository(GeneralDbContext context) : base(context)
        {
        }

        public override Employee Get(Guid role)
        {
            var jobCategoryId = context.Employees
                .Where(c => c.JobCategory == role)
                .Select(c => c.JobCategoryId)
                .Single();

            return new GhostEmployee(() => base.Get(role))
            {
                JobCategory = jobCategoryId
            };
        }

        public IEnumerable<Employee> All(Guid role)
        {
            return context.Set<Employee>()
                .AsQueryable()
                .ToList()
                .Where(c => c.JobCategory == role);
        }
       
               
        public void Delete(JobCategory entity)
        {
            var role = context.JobCategories
                        .Single(c => c.JobCategoryId == entity.JobCategory);

            context.Remove(role);
            context.SaveChanges();

        }
    }
}
