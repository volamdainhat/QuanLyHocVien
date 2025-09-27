using System.ComponentModel.DataAnnotations;

namespace StudentManagementApp.Core.Validations
{
    public class StringLengthAttribute : System.ComponentModel.DataAnnotations.StringLengthAttribute
    {
        public StringLengthAttribute(int maximumLength) : base(maximumLength)
        {
            ErrorMessage = "{0} không được vượt quá {1} ký tự";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var result = base.IsValid(value, validationContext);
            if (result != ValidationResult.Success)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return ValidationResult.Success;
        }
    }
}
