
using PreFlight.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PreFlight_API.BLL.Models
{
    public class EmployeeProxy : Employee
    {

        EmployeeRepository employeeRepository;

        public override byte[] ProfilePicture
        {
            get
            {
                if (base.ProfilePicture == null)
                {
                    base.ProfilePicture = employeeRepository.GetProfilePictureFor(FirstName + " " + LastName);
                }

                return base.ProfilePicture;
            }
        }
    }
}
