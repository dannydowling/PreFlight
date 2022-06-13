using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PreFlight_API.BLL.Models
{
    public class UserModel : Entity
    {        
        public Guid UserModelId { get; set; }
        
        [Required]
        [StringLength(45, MinimumLength = 1, ErrorMessage = "First name is too long.")]
        public virtual string FirstName { get; set; }

        [Required]
        [StringLength(45, MinimumLength = 1, ErrorMessage = "Last name is too long.")]
        public virtual string LastName { get; set; }

        [Required]
        [EmailAddress]
        public virtual string Email { get; set; }

        [StringLength(1000, ErrorMessage = "Comment length can't exceed 1000 characters.")]
        public virtual string? Comment { get; set; }

        public virtual byte[] ProfilePicture { get; set; }

        [Timestamp]
        public virtual byte[] RowVersion { get; set; }

        [DataType(DataType.Date)]
        public virtual DateTime JoinedDate { get; set; }

        [DataType(DataType.Date)]
        public virtual DateTime? ExitDate { get; set; }

        public virtual ICollection<Weather> Weathers { get; set; }

        public virtual JobCategory? JobCategory { get; set; }
        
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

    }
}
