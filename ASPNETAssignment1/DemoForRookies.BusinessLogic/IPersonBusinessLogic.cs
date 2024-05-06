using ASPNETAssignment1.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETAssignment1.BusinessLogic
{
    public interface IPersonBusinessLogic
    {
            
        public IEnumerable<Person> GetMalePersons(List<Person> people);

        public Person GetOldestPerson();

        public IEnumerable<string> GetFullNames();

        public (List<Person>, List<Person>, List<Person>) FilterByBirthYear();

        IActionResult ExportToExcel();
        IEnumerable<Person> GetMalePersons();
    }
}

