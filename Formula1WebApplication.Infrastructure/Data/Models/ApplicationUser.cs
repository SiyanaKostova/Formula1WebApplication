using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static Formula1WebApplication.Infrastructure.Constants.DataConstants;

namespace Formula1WebApplication.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(UserFirstNameMaxLength)]
        [PersonalData]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(UserLastNameMaxLength)]
        [PersonalData]
        public string LastName { get; set; } = string.Empty;

        public Organizer? Organizer { get; set; }
    }
}
