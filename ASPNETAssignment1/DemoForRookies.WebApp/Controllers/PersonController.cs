using ASPNETAssignment1.BusinessLogic;
using ASPNETAssignment1.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASPNETAssignment1.WebApp.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonBusinessLogic _personBusinessLogic;

        public PersonController(IPersonBusinessLogic personBusinessLogic)
        {
            _personBusinessLogic = personBusinessLogic;
        }

        public IActionResult ListMalePersons()
        {
            IEnumerable<Person> malePersons = _personBusinessLogic.GetMalePersons();
            return Ok(malePersons);
        }

        public IActionResult OldestPerson()
        {
            Person oldestPerson = _personBusinessLogic.GetOldestPerson();
            return Ok(oldestPerson);
        }

        public IActionResult FullNames()
        {
            IEnumerable<string> fullNames = _personBusinessLogic.GetFullNames();
            return Ok(fullNames);
        }

        public IActionResult FilterByBirthYear()
        {
            (List<Person>, List<Person>, List<Person>) filteredPeople = _personBusinessLogic.FilterByBirthYear();
            return Ok(filteredPeople);
        }

        public IActionResult ExportToExcel()
        {
            return _personBusinessLogic.ExportToExcel();
        }
    }
}