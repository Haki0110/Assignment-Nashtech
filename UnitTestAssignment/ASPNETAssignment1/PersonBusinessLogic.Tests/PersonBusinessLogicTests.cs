using ASPNETAssignment1.BusinessLogic;
using ASPNETAssignment1.Models.Models;
using ASPNETAssignment1.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ASPNETAssignment1.WebApp.Tests.BusinessLogic
{
    public class PersonBusinessLogicTests
    {
        private readonly Mock<IPersonRepositories> _mockPersonRepositories;
        private readonly IPersonBusinessLogic _businessLogic;

        public PersonBusinessLogicTests()
        {
            _mockPersonRepositories = new Mock<IPersonRepositories>();
            _businessLogic = new PersonBusinessLogic(_mockPersonRepositories.Object);
        }

        [Fact]
        public void GetAll_ReturnsAllPersons()
        {
            // Arrange
            var persons = new List<Person> { new Person { Id = 1, FirstName = "John", LastName = "Doe" } };
            _mockPersonRepositories.Setup(repo => repo.GetAll()).Returns(persons);

            // Act
            var result = _businessLogic.GetAll();

            // Assert
            Assert.Equal(persons, result);
        }

        [Fact]
        public void GetMalePersons_ReturnsMalePersons()
        {
            // Arrange
            var malePersons = new List<Person> { new Person { Id = 1, FirstName = "John", LastName = "Doe", Gender = GenderType.Male } };
            _mockPersonRepositories.Setup(repo => repo.GetMalePerson(GenderType.Male)).Returns(malePersons);

            // Act
            var result = _businessLogic.GetMalePersons(GenderType.Male);

            // Assert
            Assert.Equal(malePersons, result);
        }

        [Fact]
        public void GetOldestPerson_ReturnsOldestPerson()
        {
            // Arrange
            var persons = new List<Person>
            {
                new Person { Id = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1980, 1, 1) },
                new Person { Id = 2, FirstName = "Jane", LastName = "Doe", DateOfBirth = new DateTime(1970, 1, 1) }
            };
            _mockPersonRepositories.Setup(repo => repo.GetAll()).Returns(persons);

            // Act
            var result = _businessLogic.GetOldestPerson();

            // Assert
            Assert.Equal(persons[1], result); // Jane Doe is the oldest person
        }

        [Fact]
        public void GetFullNames_ReturnsListOfFullNames()
        {
            // Arrange
            var persons = new List<Person>
            {
                new Person { Id = 1, FirstName = "John", LastName = "Doe" },
                new Person { Id = 2, FirstName = "Jane", LastName = "Smith" }
            };
            _mockPersonRepositories.Setup(repo => repo.GetAll()).Returns(persons);

            // Act
            var result = _businessLogic.GetFullNames();

            // Assert
            var expectedFullNames = new List<string> { "Doe John", "Smith Jane" };
            Assert.Equal(expectedFullNames, result);
        }

        [Fact]
        public void FilterByBirthYear_ReturnsFilteredPeople()
        {
            // Arrange
            var persons = new List<Person>
            {
                new Person { Id = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(2000, 1, 1) },
                new Person { Id = 2, FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateTime(2001, 1, 1) },
                new Person { Id = 3, FirstName = "Bob", LastName = "Brown", DateOfBirth = new DateTime(1999, 1, 1) }
            };
            _mockPersonRepositories.Setup(repo => repo.GetAll()).Returns(persons);

            // Act
            var (equal2k, greater2k, lower2k) = _businessLogic.FilterByBirthYear();

            // Assert
            Assert.Single(equal2k);
            Assert.Single(greater2k);
            Assert.Single(lower2k);
        }

        [Fact]
        public void ExportToExcel_ReturnsFileStreamResult()
        {
            // Arrange
            var persons = new List<Person>
            {
                new Person { Id = 1, FirstName = "John", LastName = "Doe" }
            };
            _mockPersonRepositories.Setup(repo => repo.GetAll()).Returns(persons);

            // Act
            var result = _businessLogic.ExportToExcel();

            // Assert
            Assert.IsType<FileStreamResult>(result);
        }

        [Fact]
        public void GetPersonById_ReturnsPerson()
        {
            // Arrange
            var person = new Person { Id = 1, FirstName = "John", LastName = "Doe" };
            _mockPersonRepositories.Setup(repo => repo.GetById(1)).Returns(person);

            // Act
            var result = _businessLogic.GetPersonById(1);

            // Assert
            Assert.Equal(person, result);
        }

        [Fact]
        public void CreatePerson_CreatesPerson()
        {
            // Arrange
            var person = new Person { Id = 1, FirstName = "John", LastName = "Doe" };

            // Act
            _businessLogic.CreatePerson(person);

            // Assert
            _mockPersonRepositories.Verify(repo => repo.Create(person), Times.Once);
        }

        [Fact]
        public void UpdatePerson_UpdatesPerson()
        {
            // Arrange
            var person = new Person { Id = 1, FirstName = "John", LastName = "Doe" };

            // Act
            _businessLogic.UpdatePerson(person);

            // Assert
            _mockPersonRepositories.Verify(repo => repo.Update(person), Times.Once);
        }

        [Fact]
        public void DeletePerson_DeletesPerson()
        {
            // Arrange
            var personId = 1;

            // Act
            _businessLogic.DeletePerson(personId);

            // Assert
            _mockPersonRepositories.Verify(repo => repo.Delete(personId), Times.Once);
        }

        [Fact]
        public void IsUpperCaseFirstChar_ReturnsTrue_IfFirstCharIsUpperCase()
        {
            // Arrange
            string name = "John";

            // Act
            var result = PersonBusinessLogic.IsUpperCaseFirstChar(name);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsUpperCaseFirstChar_ReturnsFalse_IfFirstCharIsNotUpperCase()
        {
            // Arrange
            string name = "john";

            // Act
            var result = PersonBusinessLogic.IsUpperCaseFirstChar(name);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsContainAnyDigit_ReturnsTrue_IfStringContainsAnyDigit()
        {
            // Arrange
            string name = "John1";

            // Act
            var result = PersonBusinessLogic.IsContainAnyDigit(name);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsContainAnyDigit_ReturnsFalse_IfStringDoesNotContainAnyDigit()
        {
            // Arrange
            string name = "John";

            // Act
            var result = PersonBusinessLogic.IsContainAnyDigit(name);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsContainAllDigit_ReturnsTrue_IfStringContainsOnlyDigits()
        {
            // Arrange
            string input = "12345";

            // Act
            var result = PersonBusinessLogic.IsContainAllDigit(input);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsContainAllDigit_ReturnsFalse_IfStringDoesNotContainOnlyDigits()
        {
            // Arrange
            string input = "12345a";

            // Act
            var result = PersonBusinessLogic.IsContainAllDigit(input);

            // Assert
            Assert.False(result);
        }
    }
}

