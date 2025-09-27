using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace StudentManagementApp.Core.Validations
{
    public class EmailAddressAttribute : ValidationAttribute
    {
        private static readonly Regex _emailRegex = new Regex(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public EmailAddressAttribute()
        {
            ErrorMessage = "{0} không đúng định dạng email";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var email = value.ToString();
            if (!_emailRegex.IsMatch(email))
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }
    }
}
