
using System;
using System.Collections.Generic;
using System.Linq;
using PreFlight_API.BLL.Models;

namespace PreFlight.Infrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<UserModel>
    {
        public CustomerRepository(DBContext context) : base(context)
        {
        }

        public override UserModel Get(Guid id)
        {
            var customerId = context.Customers
                .Where(c => c.CustomerId == id)
                .Select(c => c.CustomerId)
                .Single();

            return new GhostCustomer(() => base.Get(id))
            {
                UserModelId = customerId
            };
        }

        public byte[] GetProfilePictureFor(string lookup)
        {

            //lazily load up the profile picture when asked for it.
            var profilePicture = context.Customers
                .Where(c => c.FirstName + " " + c.LastName == lookup)
                .Select(c => c.ProfilePicture)
                .Single();

            return profilePicture;
        }

        public override IEnumerable<UserModel> All()
        {
            return base.All();
        }

        public override UserModel Add (UserModel entity)
        {
            context.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public override UserModel Update(UserModel entity)
        {
            var user = context.Customers
                .Single(c => c.CustomerId == entity.UserModelId);

            user.Email =        entity.Email;
            user.FirstName =    entity.FirstName;
            user.LastName =     entity.LastName;       
            user.Comment =      entity.Comment;
            user.ExitDate =     entity.ExitDate;
            user.JoinedDate =   entity.JoinedDate;
            user.Password =     entity.Password;

            return base.Update(user);
           
        }
               
        public override void Delete(UserModel entity)
        {
            var user = context.Customers
                        .Single(c => c.CustomerId == entity.UserModelId);

            context.Remove(user);
            context.SaveChanges();

        }
    }
}
