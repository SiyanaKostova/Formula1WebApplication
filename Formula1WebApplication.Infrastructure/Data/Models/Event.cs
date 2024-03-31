using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Formula1WebApplication.Infrastructure.Constants.DataConstants;

namespace Formula1WebApplication.Infrastructure.Data.Models
{
    public class Event
    {
        [Key]
        [Comment("Unique identifier for event")]
        public int Id { get; set; }

        [Required]
        [MaxLength(EventNameMaxLength)]
        [Comment("Name of the event")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(EventDescriptionMaxLength)]
        [Comment("Detailed description of the event")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("URL to an image representing the event")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Comment("The location where the event is held")]
        [MaxLength(EventLocationMaxLength)]
        public string Location { get; set; } = string.Empty;

        [Required]
        [Comment("The date and time of the event")]
        public DateTime Date { get; set; }

        [Required]
        [Comment("Event Organizer Id")]
        public int OrganizerId { get; set; }

        [ForeignKey(nameof(OrganizerId))]
        public Organizer Organizer { get; set; } = null!;

        [Required]
        [Comment("User Id")]
        public string? UserId { get; set; }
    }
}
