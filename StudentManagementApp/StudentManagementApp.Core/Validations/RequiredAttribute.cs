using System.ComponentModel.DataAnnotations;

namespace StudentManagementApp.Core.Validations
{
    public class RequiredAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute
    {
        public RequiredAttribute() : base()
        {
            ErrorMessage = "{0} là bắt buộc";
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
