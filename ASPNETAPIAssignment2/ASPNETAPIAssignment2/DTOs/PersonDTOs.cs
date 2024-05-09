using ASPNETAPIAssignment2.Model;

namespace ASPNETAPIAssignment2.DTOs
{
    public class PersonDTOs
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public GenderType Gender { get; set; }
        public string BirthPlace { get; set; }
    }
}
