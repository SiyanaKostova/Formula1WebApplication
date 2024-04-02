using System.ComponentModel.DataAnnotations;
using static Formula1WebApplication.Core.Constants.MessageConstants;
using static Formula1WebApplication.Infrastructure.Constants.DataConstants;

namespace Formula1WebApplication.Core.Models.Event
{
    public class EventServiceModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(EventNameMaxLength,
        ErrorMessage = MaxLengthMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(EventDescriptionMaxLength,
        MinimumLength = EventDescriptionMinLength,
        ErrorMessage = LengthMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(EventLocationMaxLength,
        MinimumLength = EventLocationMinLength,
        ErrorMessage = LengthMessage)]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        public DateTime Date { get; set; }
    }
}