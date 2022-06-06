using System;
using System.Collections.Generic;
using System.Text;

namespace PreFlight_API.BLL.Models
{
    public class JobCategory
    {
        public Guid Id { get; set; }
        public JobCategoryEnum jobCategory { get; set; }
    }

   public enum JobCategoryEnum
    {
        User = 0
    }
}
