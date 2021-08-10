using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RentACar.Data.Models
{
    using static DataConstants.User;
    public class User : IdentityUser
    {
        [MaxLength(FullNameMaxLength)]
        public string FullName { get; set; }
    }
}
