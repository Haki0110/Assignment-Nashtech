using ASPNETAssignment1.BusinessLogic;
using ASPNETAssignment1.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASPNETAssignment1.WebApp.Controllers
{
    [Area("NashTech")]
    public class PersonController : Controller
    {
        private readonly PersonBusinessLogic _personBusinessLogic;

        public PersonController(PersonBusinessLogic personBusinessLogic)
        {
            _personBusinessLogic = personBusinessLogic;
        }


        public IActionResult Index()
        {
            IEnumerable<Person> allPerson = _personBusinessLogic.GetAll();
            return View(allPerson);
        }

        public IActionResult MalePerson()
        {
            IEnumerable<Person> malePersons = _personBusinessLogic.GetMalePersons(GenderType.Male);
            return View(malePersons);
        }

        public IActionResult OldestPerson()
        {
            Person oldestPerson = _personBusinessLogic.GetOldestPerson();
            return View(oldestPerson);
        }

        public IActionResult FullNames()
        {
            IEnumerable<string> fullNames = _personBusinessLogic.GetFullNames();
            return View(fullNames);
        }

        public IActionResult FilterByBirthYear()
        {
            (List<Person>, List<Person>, List<Person>) filteredPeople = _personBusinessLogic.FilterByBirthYear();
            return View(filteredPeople);
        }

        public IActionResult ExportToExcel()
        {
            return _personBusinessLogic.ExportToExcel();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                _personBusinessLogic.CreatePerson(person);
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }


        public IActionResult Edit(int id)
        {
            var person = _personBusinessLogic.GetPersonById(id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _personBusinessLogic.UpdatePerson(person);
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }


        public IActionResult Details(int id)
        {
            var person = _personBusinessLogic.GetPersonById(id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        public IActionResult Delete(int id)
        {
            var person = _personBusinessLogic.GetPersonById(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Person person)
        {
            if (person == null)
            {
                return NotFound();
            }

            _personBusinessLogic.DeletePerson(person.Id);

            // Set success message to display on Confirmation page
            TempData["SuccessMessage"] = $"Person {person.FirstName} {person.LastName} was removed from the list successfully!";

            // Redirect to Confirmation page
            return RedirectToAction("Confirmation");
        }

        public IActionResult Confirmation()
        {
            var successMessage = TempData["SuccessMessage"] as string;
            ViewBag.SuccessMessage = successMessage;

            return View();
        }
    }
}