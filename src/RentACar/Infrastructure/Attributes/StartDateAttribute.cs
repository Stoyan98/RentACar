using System;
using System.ComponentModel.DataAnnotations;

namespace RentACar.Infrastructure.Attributes
{
    public sealed class StartDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime startDate = Convert.ToDateTime(value);
            if (startDate >= DateTime.Now)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage);
            }
        }
    }
}
