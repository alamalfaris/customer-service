using System.ComponentModel.DataAnnotations;

namespace customer_service.Helpers
{
    public static class ModelValidator
    {
        public static ValidationResult ValidateDateOfBirth(DateTime dateOfBirth, ValidationContext context)
        {
            if (dateOfBirth > DateTime.Now)
            {
                return new ValidationResult("Date of Birth cannot be in the future.");
            }
            return ValidationResult.Success!;
        }
    }
}
