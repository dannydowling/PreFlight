
using PreFlight.Infrastructure.Repositories;
using PreFlight_API.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PreFlightAI.Shared.Customers.Proxies
{
    public class CustomerProxy : UserModel
    {

        UserRepository userRepository;

        public override byte[] ProfilePicture
        {
            get
            {
                if (base.ProfilePicture == null)
                {
                    base.ProfilePicture = userRepository.GetProfilePictureFor(FirstName + " " + LastName);
                }

                return base.ProfilePicture;
            }
        }
    }
}
