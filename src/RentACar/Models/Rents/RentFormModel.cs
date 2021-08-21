using RentACar.Infrastructure.Attributes;
using RentACar.Services.Rents.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace RentACar.Models.Rents
{
    using static Data.DataConstants.Rent;

    public class RentFormModel : IRentModel
    {
        public int CarId { get; init; }

        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string FirstName { get; init; }

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        public string LastName { get; init; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [StartDate(ErrorMessage = "Start Date can not be in past")]
        public DateTime StartDate { get; init; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [EndDate(ErrorMessage = "End date can not be less than start date")]
        public DateTime EndDate { get; init; }

        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; init; }
    }
}
