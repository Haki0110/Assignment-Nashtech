using ASPNETAssignment1.Models.Models;
using ASPNETAssignment1.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ASPNETAssignment1.BusinessLogic
{
    public class PersonBusinessLogic : IPersonBusinessLogic
    {
        private readonly IPersonRepositories _personRepositories;

        public PersonBusinessLogic(IPersonRepositories personRepositories)
        {
            _personRepositories = personRepositories;
        }

        public IEnumerable<Person> GetAll()
        {
            return _personRepositories.GetAll();
        }

        public IEnumerable<Person> GetMalePersons(GenderType genderType)
        {
            return _personRepositories.GetMalePerson(genderType);
        }

        public Person GetOldestPerson()
        {
            Person oldestPerson = null;
            int maxAge = int.MinValue;
            foreach (Person person in _personRepositories.GetAll())
            {
                if (person.Age > maxAge)
                {
                    maxAge = person.Age;
                    oldestPerson = person;
                }
            }
            return oldestPerson;
        }

        public IEnumerable<string> GetFullNames()
        {
            return _personRepositories.GetAll().Select(p => p.LastName + " " + p.FirstName).ToList();
        }

        public (List<Person>, List<Person>, List<Person>) FilterByBirthYear()
        {
            List<Person> equal2k = _personRepositories.GetAll().Where(p => p.DateOfBirth.Year == 2000).ToList();
            List<Person> greater2k = _personRepositories.GetAll().Where(p => p.DateOfBirth.Year > 2000).ToList();
            List<Person> lower2k = _personRepositories.GetAll().Where(p => p.DateOfBirth.Year < 2000).ToList();
            return (equal2k, greater2k, lower2k);
        }

        public IActionResult ExportToExcel()
        {
            var people = _personRepositories.GetAll();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("People");

                // Header
                worksheet.Cells[1, 1].Value = "First Name";
                worksheet.Cells[1, 2].Value = "Last Name";
                worksheet.Cells[1, 3].Value = "Gender";
                worksheet.Cells[1, 4].Value = "Date Of Birth";
                worksheet.Cells[1, 5].Value = "Phone Number";
                worksheet.Cells[1, 6].Value = "Birthplace";
                worksheet.Cells[1, 7].Value = "Age";
                worksheet.Cells[1, 8].Value = "Is Graduated";

                // Data
                int row = 2;
                foreach (var person in people)
                {
                    worksheet.Cells[row, 1].Value = person.FirstName;
                    worksheet.Cells[row, 2].Value = person.LastName;
                    worksheet.Cells[row, 3].Value = person.Gender.ToString();
                    worksheet.Cells[row, 4].Value = person.DateOfBirth.ToString("dd/MM/yyyy");
                    worksheet.Cells[row, 5].Value = person.PhoneNumber;
                    worksheet.Cells[row, 6].Value = person.BirthPlace;
                    worksheet.Cells[row, 7].Value = person.Age;
                    worksheet.Cells[row, 8].Value = person.IsGraduated;
                    row++;
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                MemoryStream stream = new MemoryStream();
                excelPackage.SaveAs(stream);
                stream.Position = 0;

                return new FileStreamResult(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    FileDownloadName = "people.xlsx"
                };
            }
        }

        public Person GetPersonById(int id)
        {
            return _personRepositories.GetById(id);
        }

        public void CreatePerson(Person person)
        {
            _personRepositories.Create(person);
        }

        public void UpdatePerson(Person person)
        {
            _personRepositories.Update(person);
        }

        public void DeletePerson(int id)
        {
            _personRepositories.Delete(id);
        }

        public static bool IsUpperCaseFirstChar(string name)
        {
            return !string.IsNullOrEmpty(name) && char.IsUpper(name[0]) && name.Substring(1).ToLower() == name.Substring(1);
        }

        public static bool IsContainAnyDigit(string name)
        {
            foreach (char c in name)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsContainAllDigit(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
