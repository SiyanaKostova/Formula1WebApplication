using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HouseRentingSystem.Infrastructure.Constants.DataConstants;

namespace Formula1WebApplication.Infrastructure.Data.Models
{
    public class Organizer
    {
        [Key]
        [Comment("Unique identifier for organizer")]
        public int Id { get; set; }

        [Required]
        [MaxLength(OrganizerPhoneNumberMaxLength)]
        [Comment("Contact phone number for organizer")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [Comment("Organizer User Id")]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;
    }
}
