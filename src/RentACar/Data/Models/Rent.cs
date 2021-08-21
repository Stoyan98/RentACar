using System;
using System.ComponentModel.DataAnnotations;

namespace RentACar.Data.Models
{
    using static DataConstants.Rent;

    public class Rent
    {
        public int Id { get; set; }

        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        public string LastName { get; set; }

        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime StartDate { get; init; }

        [Required]
        public DateTime EndDate { get; init; }

        public int CarId { get; set; }

        public Car Car { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
