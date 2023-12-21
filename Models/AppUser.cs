using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace nov30task.Models

{
    public class AppUser :IdentityUser
    {
        //public string UserName { get; set; }

        public string ProfileImageURL { get; set; }
        public override bool TwoFactorEnabled { get => false; }

        [NotMapped]
        public override string PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }
        [NotMapped]

        public override bool PhoneNumberConfirmed { get => base.PhoneNumberConfirmed; set => base.PhoneNumberConfirmed = value; }
    }
}
