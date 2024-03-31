using static Formula1WebApplication.Infrastructure.Constants.DataConstants;
using static Formula1WebApplication.Core.Constants.MessageConstants;
using System.ComponentModel.DataAnnotations;

namespace Formula1WebApplication.Core.Models.Organizer
{
	public class BecomeOrganizerFormModel
	{
		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(OrganizerPhoneNumberMaxLength,
			MinimumLength = OrganizerPhoneNumberMinLength,
			ErrorMessage = LengthMessage)]
		[Display(Name = "Phone number")]
		[Phone]
		public string PhoneNumber { get; set; } = null!;
	}
}
