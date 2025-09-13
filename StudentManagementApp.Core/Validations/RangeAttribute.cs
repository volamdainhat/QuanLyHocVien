using System.ComponentModel.DataAnnotations;

namespace StudentManagementApp.Core.Validations
{
    public class RangeAttribute : System.ComponentModel.DataAnnotations.RangeAttribute
    {
        public RangeAttribute(double minimum, double maximum) : base(minimum, maximum)
        {
            ErrorMessage = "{0} phải nằm trong khoảng từ {1} đến {2}";
        }

        public RangeAttribute(int minimum, int maximum) : base(minimum, maximum)
        {
            ErrorMessage = "{0} phải nằm trong khoảng từ {1} đến {2}";
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
