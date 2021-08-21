using System;
using System.ComponentModel.DataAnnotations;

namespace RentACar.Infrastructure.Attributes
{
    public sealed class EndDateAttribute : ValidationAttribute
    {
        public string StartDateProperty { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime endDate = Convert.ToDateTime(value);

            var startDatePropertyInfo = validationContext.ObjectType.GetProperty(StartDateProperty);
            var startDate = (DateTime)startDatePropertyInfo.GetValue(validationContext.ObjectInstance, null);

            if (endDate > startDate)
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
