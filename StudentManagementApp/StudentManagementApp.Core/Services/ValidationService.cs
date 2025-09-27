using System.ComponentModel.DataAnnotations;

namespace StudentManagementApp.Core.Services
{
    public class ValidationService : IValidationService
    {
        public ValidationResult Validate(object entity)
        {
            var validationContext = new ValidationContext(entity);
            return Validator.TryValidateObject(entity, validationContext, null, true)
                ? ValidationResult.Success
                : new ValidationResult("Validation failed");
        }

        public IEnumerable<ValidationResult> ValidateWithDetails(object entity)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(entity);

            Validator.TryValidateObject(entity, validationContext, validationResults, true);

            return validationResults;
        }

        public bool TryValidate(object entity, out List<ValidationResult> validationResults)
        {
            validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(entity);

            return Validator.TryValidateObject(entity, validationContext, validationResults, true);
        }
    }
}
