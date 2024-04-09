using Formula1WebApplication.Core.Contracts.InterfaceModels;
using System.ComponentModel.DataAnnotations;
using static Formula1WebApplication.Core.Constants.MessageConstants;
using static Formula1WebApplication.Infrastructure.Constants.DataConstants;

namespace Formula1WebApplication.Core.Models.Race
{
    public class RaceServiceModel : IRaceModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(RaceNameMaxLength,
         ErrorMessage = MaxLengthMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(RaceLocationMaxLength,
        MinimumLength = RaceLocationMinLength,
         ErrorMessage = LengthMessage)]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        public int Laps { get; set; }

        [StringLength(RaceCircuitInfoMaxLength,
        MinimumLength = RaceCircuitInfoMinLength,
         ErrorMessage = LengthMessage)]
        public string CircuitInfo { get; set; } = string.Empty;
    }
}