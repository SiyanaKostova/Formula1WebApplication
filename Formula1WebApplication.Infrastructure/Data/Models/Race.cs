using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Formula1WebApplication.Infrastructure.Constants.DataConstants;

namespace Formula1WebApplication.Infrastructure.Data.Models
{
    public class Race
    {
        [Key]
        [Comment("Unique identifier for race")]
        public int Id { get; set; }

        [Required]
        [MaxLength(RaceNameMaxLength)]
        [Comment("Name of the race")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(RaceLocationMaxLength)]
        [Comment("The location where the race is held")]
        public string Location { get; set; } = string.Empty;

        [Required]
        [Comment("The date and time of the race")]
        public DateTime Date { get; set; }

        [Required]
        [Comment("URL to an image representing the race")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Comment("The number of laps in the race")]
        public int Laps { get; set; }

        [MaxLength(RaceCircuitInfoMaxLength)]
        [Comment("Information about the race circuit")]
        public string CircuitInfo { get; set; } = string.Empty;

        [Required]
        [Comment("Race Organizer Id")]
        public int OrganizerId { get; set; }

        [ForeignKey(nameof(OrganizerId))]
        public Organizer Organizer { get; set; } = null!;

        [Comment("User Id")]
        public string? UserId { get; set; }
    }
}
