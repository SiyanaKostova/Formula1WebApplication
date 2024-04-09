using System.ComponentModel.DataAnnotations;
using static Formula1WebApplication.Core.Constants.MessageConstants;
using static Formula1WebApplication.Infrastructure.Constants.DataConstants;

namespace Formula1WebApplication.Core.Models.Pilot
{
    public class PilotDetailsServiceModel 
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PilotNameMaxLength,
        ErrorMessage = MaxLengthMessage)]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PilotNameMaxLength,
        ErrorMessage = MaxLengthMessage)]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "Nationality")]
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PilotNationalityMaxLength,
        ErrorMessage = MaxLengthMessage)]
        public string Nationality { get; set; } = string.Empty;

        [Display(Name = "Team")]
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PilotTeamNameMaxLength,
        ErrorMessage = MaxLengthMessage)]
        public string TeamName { get; set; } = string.Empty;

        [Display(Name = "Biography")]
        [StringLength(PilotBiographyMaxLength,
        MinimumLength = PilotBiographyMinLength,
        ErrorMessage = LengthMessage)]
        public string Biography { get; set; } = string.Empty;

        [Display(Name = "Image")]
        public string ImagePath { get; set; } = string.Empty;
    }
}
