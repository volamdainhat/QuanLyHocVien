using System.ComponentModel.DataAnnotations;

namespace StudentManagementApp.Core.Services
{
    public interface IValidationService
    {
        ValidationResult Validate(object entity);
        IEnumerable<ValidationResult> ValidateWithDetails(object entity);
        bool TryValidate(object entity, out List<ValidationResult> validationResults);
    }
}
