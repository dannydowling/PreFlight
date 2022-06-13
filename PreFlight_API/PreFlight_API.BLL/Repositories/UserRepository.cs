
using System;
using System.Collections.Generic;
using System.Linq;
using PreFlight_API.BLL.Contexts;
using PreFlight_API.BLL.Models;

namespace PreFlight.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<UserModel>
    {
        public UserRepository(GeneralDbContext context) : base(context)
        {
        }

        public override UserModel Get(Guid id)
        {
            var customerId = context.Users
                .Where(c => c.UserModelId == id)
                .Select(c => c.UserModelId)
                .Single();

            return new GhostCustomer(() => base.Get(id))
            {
                UserModelId = customerId
            };
        }

        public byte[] GetProfilePictureFor(string lookup)
        {

            //lazily load up the profile picture when asked for it.
            var profilePicture = context.Users
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
            var user = context.Users
                .Single(c => c.UserModelId == entity.UserModelId);

            user.Email =        entity.Email;
            user.FirstName =    entity.FirstName;
            user.LastName =     entity.LastName;       
            user.Comment =      entity.Comment;
            user.ExitDate =     entity.ExitDate;
            user.JoinedDate =   entity.JoinedDate;
            user.Password =     entity.Password;

            return base.Update(user);
           
        }

        public void Save(UserModel user)
        {

            if (user.Id == 0)
            {
                var lastId = _lastId();
                SetId(user, lastId++);
            }

            // Saving to the database
            var old_User_Info = context.Find<UserModel>(user.Id);
            context.Remove(old_User_Info);

            context.Add(user);
            context.SaveChanges();
        }

        private long _lastId()
        {
            var weather = context.Weathers.Where(x => x.Id == x.Id).Max();
            return weather.Id;

        }

        private static void SetId(Entity entity, long id)
        {
            entity.GetType().GetProperty(nameof(Entity.Id)).SetValue(entity, id);
        }

        public override void Delete(UserModel entity)
        {
            var user = context.Users
                        .Single(c => c.UserModelId == entity.UserModelId);

            context.Remove(user);
            context.SaveChanges();

        }
    }
}
