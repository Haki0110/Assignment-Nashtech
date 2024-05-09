using System.Collections.Generic;

namespace ASPNETAPIAssignment2.Model
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public Dictionary<string, string> Errors { get; set; }

        public ValidationResult()
        {
            IsValid = false;
            Errors = new Dictionary<string, string>();
        }
    }
}
