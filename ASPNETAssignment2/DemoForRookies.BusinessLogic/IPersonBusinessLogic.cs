using ASPNETAssignment1.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETAssignment1.BusinessLogic
{
    public interface IPersonBusinessLogic
    {

        public IEnumerable<Person> GetAll();
            
        public IEnumerable<Person> GetMalePersons(GenderType genderType);

        public Person GetOldestPerson();

        public IEnumerable<string> GetFullNames();

        public (List<Person>, List<Person>, List<Person>) FilterByBirthYear();

        IActionResult ExportToExcel();

        Person GetPersonById(int id);
        void CreatePerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(int id);

    }
}

