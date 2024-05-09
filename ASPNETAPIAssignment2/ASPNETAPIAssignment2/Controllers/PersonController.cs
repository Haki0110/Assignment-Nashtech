using ASPNETAPIAssignment2.DTOs;
using ASPNETAPIAssignment2.Model;
using ASPNETAPIAssignment2.Services;
using Microsoft.AspNetCore.Mvc;
using ASPNETAPIAssignment2.Services.Validation;

namespace ASPNETAPIAssignment2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        private readonly ILogger<PersonController> _logger;

        [HttpPost]
        public IActionResult Create([FromBody] PersonDTOs personDTOs)
        {
            var success = _personService.Create(personDTOs);
            if (!success)
            {
                return BadRequest(ValidationMessage.RequredField);
            }

            return Ok();
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var people = _personService.GetAll();
            return Ok(people.ToJsonString()); 
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePeople(Guid id)
        {
            _personService.DeletePerson(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult EditPeople(Guid id, [FromBody] Person person)
        {
            var getPeople = _personService.GetSpePerson(id);
            if (getPeople == null)
                return NotFound();

            getPeople.FirstName = person.FirstName;
            getPeople.LastName = person.LastName;
            getPeople.DateOfBirth = person.DateOfBirth;
            getPeople.Gender = person.Gender;
            getPeople.BirthPlace = person.BirthPlace;

            _personService.UpdatePerson(getPeople);
            return NoContent();
        }

        [HttpGet("filter")]
        public IActionResult FilteredPeople(string name = null, string gender = null, string birthPlace = null)
        {
            if (name == null && gender == null && birthPlace == null)
            {
                var allPeople = _personService.GetAll();
                return Ok(allPeople);
            }

            var filter = _personService.FilterPeople(name, gender, birthPlace);
            if (filter == null)
                return NotFound();

            return Ok(filter);
        }



    }
}
