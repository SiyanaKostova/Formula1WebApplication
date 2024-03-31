using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Formula1WebApplication.Infrastructure.Constants.DataConstants;

namespace Formula1WebApplication.Infrastructure.Data.Models
{
    public class Pilot
    {
        [Key]
        [Comment("Unique identifier for pilot")]
        public int Id { get; set; }

        [Required]
        [MaxLength(PilotNameMaxLength)]
        [Comment("Pilot's first name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(PilotNameMaxLength)]
        [Comment("Pilot's last name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(PilotNationalityMaxLength)]
        [Comment("Pilot's nationality")]
        public string Nationality { get; set; } = string.Empty;

        [Required]
        [MaxLength(PilotTeamNameMaxLength)]
        [Comment("Name of the team the pilot is associated with")]
        public string TeamName { get; set; } = string.Empty;

        [MaxLength(PilotBiographyMaxLength)]
        [Comment("Short biography of the pilot")]
        public string Biography { get; set; } = string.Empty;

        [Required]
        [Comment("Path to the pilot's image")]
        public string ImagePath { get; set; } = string.Empty;
    }
}
