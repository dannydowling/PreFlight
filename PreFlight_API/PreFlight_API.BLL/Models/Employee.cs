using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PreFlight_API.BLL.Models
{
    public class Employee : UserModel
    {       
        public Guid EmployeeId { get; set; }

        [DataType(DataType.Date)]
        public virtual DateTime BirthDate { get; set; }

        public virtual string Street { get; set; }
        public virtual string Zip { get; set; }

        public virtual string City { get; set; }

        public virtual JobCategoryEnum jobCategoryEnum { get; set; }

        [DataType(DataType.PhoneNumber)]
        public virtual string PhoneNumber { get; set; }

        public virtual ICollection<Location> Locations { get; set; }

   
       

    }
}
