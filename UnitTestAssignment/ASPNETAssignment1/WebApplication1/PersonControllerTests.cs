using ASPNETAssignment1.BusinessLogic;
using ASPNETAssignment1.Models.Models;
using ASPNETAssignment1.WebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace ASPNETAssignment1.WebApp.Tests.Controllers
{
    public class PersonControllerTests
    {
        private readonly Mock<PersonBusinessLogic> _mockPersonBusinessLogic;
        private readonly PersonController _controller;

        public PersonControllerTests()
        {
            _mockPersonBusinessLogic = new Mock<PersonBusinessLogic>();
            _controller = new PersonController(_mockPersonBusinessLogic.Object);
        }

        [Fact]
        public void Index_ReturnsViewResult_WithListOfPersons()
        {
            // Arrange
            _mockPersonBusinessLogic.Setup(bl => bl.GetAll()).Returns(new List<Person>());

            // Act
            var result = _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<IEnumerable<Person>>(viewResult.Model);
        }

        [Fact]
        public void MalePerson_ReturnsViewResult_WithListOfMalePersons()
        {
            // Arrange
            _mockPersonBusinessLogic.Setup(bl => bl.GetMalePersons(GenderType.Male)).Returns(new List<Person>());

            // Act
            var result = _controller.MalePerson();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<IEnumerable<Person>>(viewResult.Model);
        }

        [Fact]
        public void OldestPerson_ReturnsViewResult_WithOldestPerson()
        {
            // Arrange
            _mockPersonBusinessLogic.Setup(bl => bl.GetOldestPerson()).Returns(new Person());

            // Act
            var result = _controller.OldestPerson();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<Person>(viewResult.Model);
        }

        [Fact]
        public void FullNames_ReturnsViewResult_WithListOfFullNames()
        {
            // Arrange
            _mockPersonBusinessLogic.Setup(bl => bl.GetFullNames()).Returns(new List<string>());

            // Act
            var result = _controller.FullNames();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<IEnumerable<string>>(viewResult.Model);
        }

        [Fact]
        public void FilterByBirthYear_ReturnsViewResult_WithFilteredPeople()
        {
            // Arrange
            _mockPersonBusinessLogic.Setup(bl => bl.FilterByBirthYear())
                .Returns((new List<Person>(), new List<Person>(), new List<Person>()));

            // Act
            var result = _controller.FilterByBirthYear();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<(List<Person>, List<Person>, List<Person>)>(viewResult.Model);
        }

        [Fact]
        public void ExportToExcel_ReturnsFileStreamResult()
        {
            // Arrange
            _mockPersonBusinessLogic.Setup(bl => bl.ExportToExcel())
                .Returns(new FileStreamResult(new System.IO.MemoryStream(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"));

            // Act
            var result = _controller.ExportToExcel();

            // Assert
            Assert.IsType<FileStreamResult>(result);
        }

        [Fact]
        public void Create_ReturnsViewResult()
        {
            // Act
            var result = _controller.Create();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Create_Post_ReturnsRedirectToActionResult_WhenModelStateIsValid()
        {
            // Arrange
            var person = new Person { Id = 1, FirstName = "John", LastName = "Doe" };
            _controller.ModelState.Clear();

            // Act
            var result = _controller.Create(person);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public void Create_Post_ReturnsViewResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var person = new Person { Id = 1, FirstName = "John", LastName = "Doe" };
            _controller.ModelState.AddModelError("FirstName", "Required");

            // Act
            var result = _controller.Create(person);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(person, viewResult.Model);
        }

        [Fact]
        public void Edit_ReturnsViewResult_WithPerson()
        {
            // Arrange
            var person = new Person { Id = 1, FirstName = "John", LastName = "Doe" };
            _mockPersonBusinessLogic.Setup(bl => bl.GetPersonById(1)).Returns(person);

            // Act
            var result = _controller.Edit(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(person, viewResult.Model);
        }

        [Fact]
        public void Edit_ReturnsNotFoundResult_WhenPersonIsNull()
        {
            // Arrange
            _mockPersonBusinessLogic.Setup(bl => bl.GetPersonById(1)).Returns((Person)null);

            // Act
            var result = _controller.Edit(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Edit_Post_ReturnsBadRequest_WhenIdDoesNotMatchPersonId()
        {
            // Arrange
            var person = new Person { Id = 1, FirstName = "John", LastName = "Doe" };

            // Act
            var result = _controller.Edit(2, person);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void Edit_Post_ReturnsRedirectToActionResult_WhenModelStateIsValid()
        {
            // Arrange
            var person = new Person { Id = 1, FirstName = "John", LastName = "Doe" };
            _controller.ModelState.Clear();

            // Act
            var result = _controller.Edit(1, person);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public void Edit_Post_ReturnsViewResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var person = new Person { Id = 1, FirstName = "John", LastName = "Doe" };
            _controller.ModelState.AddModelError("FirstName", "Required");

            // Act
            var result = _controller.Edit(1, person);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(person, viewResult.Model);
        }

        [Fact]
        public void Details_ReturnsViewResult_WithPerson()
        {
            // Arrange
            var person = new Person { Id = 1, FirstName = "John", LastName = "Doe" };
            _mockPersonBusinessLogic.Setup(bl => bl.GetPersonById(1)).Returns(person);

            // Act
            var result = _controller.Details(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(person, viewResult.Model);
        }

        [Fact]
        public void Details_ReturnsNotFoundResult_WhenPersonIsNull()
        {
            // Arrange
            _mockPersonBusinessLogic.Setup(bl => bl.GetPersonById(1)).Returns((Person)null);

            // Act
            var result = _controller.Details(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Delete_ReturnsViewResult_WithPerson()
        {
            // Arrange
            var person = new Person { Id = 1, FirstName = "John", LastName = "Doe" };
            _mockPersonBusinessLogic.Setup(bl => bl.GetPersonById(1)).Returns(person);

            // Act
            var result = _controller.Delete(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(person, viewResult.Model);
        }

        [Fact]
        public void Delete_ReturnsNotFoundResult_WhenPersonIsNull()
        {
            // Arrange
            _mockPersonBusinessLogic.Setup(bl => bl.GetPersonById(1)).Returns((Person)null);

            // Act
            var result = _controller.Delete(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Delete_Post_ReturnsRedirectToActionResult_AfterDeletingPerson()
        {
            // Arrange
            var person = new Person { Id = 1, FirstName = "John", LastName = "Doe" };
            _controller.TempData = new Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary(
                new DefaultHttpContext(),
                Mock.Of<Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataProvider>());

            // Act
            var result = _controller.Delete(person);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Confirmation", redirectToActionResult.ActionName);
            Assert.Equal($"Person {person.FirstName} {person.LastName} was removed from the list successfully!", _controller.TempData["SuccessMessage"]);
        }

        [Fact]
        public void Confirmation_ReturnsViewResult_WithSuccessMessage()
        {
            // Arrange
            _controller.TempData = new Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary(
                new DefaultHttpContext(),
                Mock.Of<Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataProvider>());
            _controller.TempData["SuccessMessage"] = "Success message";

            // Act
            var result = _controller.Confirmation();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Success message", viewResult.ViewData["SuccessMessage"]);
        }
    }
}
