using System;
using System.Collections.Generic;
using System.Text;

namespace PreFlight_API.BLL.Models
{
    public class GhostEmployee : EmployeeProxy
    {
        private LoadStatus status;
        private readonly Func<Employee> load;

        public bool IsGhost => status == LoadStatus.GHOST;
        public bool IsLoaded => status == LoadStatus.LOADED;

        public GhostEmployee(Func<Employee> load) : base()
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

        public override DateTime BirthDate
        {
            get
            {
                Load();

                return base.BirthDate;
            }
            set
            {
                Load();

                base.BirthDate = value;
            }
        }

        public override string Street
        {
            get
            {
                Load();

                return base.Street;
            }
            set
            {
                Load();

                base.Street = value;
            }
        }

        public override string Zip
        {
            get
            {
                Load();

                return base.Zip;
            }
            set
            {
                Load();

                base.Zip = value;
            }
        }

        public override string City
        {
            get
            {
                Load();

                return base.City;
            }
            set
            {
                Load();

                base.City = value;
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

 
  
        public override string PhoneNumber 
        {
            get
            {
                Load();

                return base.PhoneNumber;
            }
            set
            {
                Load();

                base.PhoneNumber = value;
            }
        }

        public void Load()
        {
            if (IsGhost)
            {
                status = LoadStatus.LOADING;

                var employee = load();
                base.FirstName = employee.FirstName;
                base.LastName = employee.LastName;
                base.Email = employee.Email;
                base.Comment = employee.Comment;
                base.JoinedDate = employee.JoinedDate;
                base.ExitDate = employee.ExitDate;
                base.Password = employee.Password;
                base.BirthDate = employee.BirthDate;
                base.Street = employee.Street;
                base.Zip = employee.Zip;
                base.City = employee.City;
                base.ProfilePicture = employee.ProfilePicture;
                base.PhoneNumber = employee.PhoneNumber;


                status = LoadStatus.LOADED;
            }
        }
    }

    enum LoadStatus { GHOST, LOADING, LOADED };
}
