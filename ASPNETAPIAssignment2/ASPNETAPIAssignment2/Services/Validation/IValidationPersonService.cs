using ASPNETAPIAssignment2.DTOs;
using ASPNETAPIAssignment2.Model;

namespace ASPNETAPIAssignment2.Services.Validation
{
    public interface IValidationPersonService
    {
        public Model.ValidationResult Validate(PersonDTOs person);
    }
}
