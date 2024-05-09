using ASPNETAPIAssignment2.DTOs;
using ASPNETAPIAssignment2.Model;
using ASPNETAPIAssignment2.Services.Validation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASPNETAPIAssignment2.Services
{
    public class PersonService : IPersonService
    {
        private readonly List<Person> _people;
        private readonly IValidationPersonService _validationPersonService;

        public PersonService(IValidationPersonService validationPersonService)
        {
            _validationPersonService = validationPersonService;
            _people = Person.GetDummyData();
        }

        public List<Person> GetAll()
        {
            return _people;
        }

        public bool Create(PersonDTOs personDTOs)
        {
            var validationResult = _validationPersonService.Validate(personDTOs);
            if (!validationResult.IsValid)
            {
                return false;
            }

            var newPerson = new Person
            {
                Id = Guid.NewGuid(),
                FirstName = personDTOs.FirstName,
                LastName = personDTOs.LastName,
                Gender = personDTOs.Gender,
                DateOfBirth = personDTOs.DateOfBirth,
                BirthPlace = personDTOs.BirthPlace
            };

            _people.Add(newPerson);
            return true;
        }

        public void UpdatePerson(Person personImplement)
        {
            var editPerson = _people.FirstOrDefault(t => t.Id == personImplement.Id);
            if (editPerson != null)
            {
                editPerson.FirstName = personImplement.FirstName;
                editPerson.LastName = personImplement.LastName;
                editPerson.Gender = personImplement.Gender;
                editPerson.DateOfBirth = personImplement.DateOfBirth;
                editPerson.BirthPlace = personImplement.BirthPlace;
            }
        }

        public void DeletePerson(Guid id)
        {
            var deletePerson = _people.FirstOrDefault(t => t.Id == id);
            if (deletePerson != null)
            {
                _people.Remove(deletePerson);
            }
        }

        public IEnumerable<Person> FilterPeople(string name, string gender, string birthPlace)
        {
            var filteredPeople = _people.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                filteredPeople = filteredPeople.Where(p => p.FirstName.Contains(name) || p.LastName.Contains(name));

            if (!string.IsNullOrEmpty(gender))
                filteredPeople = filteredPeople.Where(p => p.Gender.ToString().ToLower() == gender.ToLower());

            if (!string.IsNullOrEmpty(birthPlace))
                filteredPeople = filteredPeople.Where(p => p.BirthPlace.ToLower() == birthPlace.ToLower());

            return filteredPeople.ToList();
        }

        public Person GetSpePerson(Guid id)
        {
            return _people.FirstOrDefault(p => p.Id == id);
        }
    }
}
