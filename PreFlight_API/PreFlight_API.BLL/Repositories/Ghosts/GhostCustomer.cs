
using PreFlightAI.Shared.Customers.Proxies;
using System;

namespace PreFlight_API.BLL.Models
{
    public class GhostCustomer : CustomerProxy
    {
        private LoadStatus status;
        private readonly Func<UserModel> load;

        public bool IsGhost => status == LoadStatus.GHOST;
        public bool IsLoaded => status == LoadStatus.LOADED;

        public GhostCustomer(Func<UserModel> load) : base()
        {
            this.load = load;
            status = LoadStatus.GHOST;
        }

        public override string FirstName
        {
            get
            {
                Load();

                return base.FirstName;
            }
            set
            {
                Load();

                base.FirstName = value;
            }
        }

        public override string LastName
        {
            get
            {
                Load();

                return base.LastName;
            }
            set
            {
                Load();

                base.LastName = value;
            }
        }

        public override string Email
        {
            get
            {
                Load();

                return base.Email;
            }
            set
            {
                Load();

                base.Email = value;
            }
        }

        public override string Comment
        {
            get
            {
                Load();

                return base.Comment;
            }
            set
            {
                Load();

                base.Comment = value;
            }
        }

        public override byte[] ProfilePicture
        {
            get
            {
                Load();

                return base.ProfilePicture;
            }
            set
            {
                Load();

                base.ProfilePicture = value;
            }
        }

        
        public void Load()
        {
            if (IsGhost)
            {
                status = LoadStatus.LOADING;

                var user = load();
                base.FirstName = user.FirstName;
                base.LastName = user.LastName;
                base.Email = user.Email;
                base.Comment = user.Comment;
                base.JoinedDate = user.JoinedDate;
                base.ExitDate = user.ExitDate;
                base.Password = user.Password;               
                base.ProfilePicture = user.ProfilePicture;
                status = LoadStatus.LOADED;
            }
        }
    }

}
