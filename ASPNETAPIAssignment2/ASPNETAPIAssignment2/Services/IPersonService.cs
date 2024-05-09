using ASPNETAPIAssignment2.DTOs;
using ASPNETAPIAssignment2.Model;

namespace ASPNETAPIAssignment2.Services
{
    public interface IPersonService
    {
        public bool Create(PersonDTOs personDTOs);
        public void UpdatePerson(Person personImplement);
        public void DeletePerson(Guid id);
        public IEnumerable<Person> FilterPeople(string name, string gender, string birthPlace);
        public List<Person> GetAll();
        public Person GetSpePerson(Guid id);

    }
}
