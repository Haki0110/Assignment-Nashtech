using ASPNETAPIAssignment2.DTOs;
using ASPNETAPIAssignment2.Model;

namespace ASPNETAPIAssignment2.Services.Validation
{
    public class ValidationPersonService : IValidationPersonService
    {
        public ValidationResult Validate(PersonDTOs person)
        {
            var validationResult = new ValidationResult();

            if (person == null)
            {
                validationResult.Errors[nameof(Person)] = ValidationMessage.ObjectIsNotNull;
                return validationResult;
            }

            if (string.IsNullOrEmpty(person.FirstName))
            {
                validationResult.Errors[nameof(Person.FirstName)] = ValidationMessage.FirstNameIsRequired;
            }

            if (string.IsNullOrEmpty(person.LastName))
            {
                validationResult.Errors[nameof(Person.LastName)] = ValidationMessage.LastNameIsRequired;
            }


            validationResult.IsValid = validationResult.Errors.Count == 0;
            return validationResult;
        }
    }
}
