using PreFlight_API.BLL.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.ComponentModel.DataAnnotations;

namespace PreFlight_API.API.Swagger
{
    public class JobCategoryModelExample : IExamplesProvider<JobCategory>
    {
        public JobCategory GetExamples()
        {
            return new JobCategory
            {
                Id = Guid.NewGuid(),
                jobCategory = JobCategoryEnum.User               
            };
        }
    }
}
