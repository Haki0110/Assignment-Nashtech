using ASPNETAssignment1.Models.Models;
using ASPNETAssignment1.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace ASPNETAssignment1.BusinessLogic
{

    public class PersonBusinessLogic : IPersonBusinessLogic
    {
        public readonly IPersonRepositories _personRepositories;
        public PersonBusinessLogic(IPersonRepositories personRepositories)
        {
            _personRepositories = personRepositories;
        }

        IEnumerable<Person> IPersonBusinessLogic.GetMalePersons()
        {


            return _personRepositories.getList().Where(p => p.Gender == GenderType.Male);
    }

        Person IPersonBusinessLogic.GetOldestPerson()
        {
            Person oldestPerson = null;
            int maxAge = int.MinValue;
            foreach (Person person in _personRepositories.getList())
            {
                if (person.Age > maxAge)
                {
                    maxAge = person.Age;
                    oldestPerson = person;
                }
            }
            return oldestPerson;
        }

        IEnumerable<string> IPersonBusinessLogic.GetFullNames()
        {
            return _personRepositories.getList().Select(p => p.LastName + " " + p.FirstName).ToList();
        }

        (List<Person>, List<Person>, List<Person>) IPersonBusinessLogic.FilterByBirthYear()
        {
            List<Person> equal2k = _personRepositories.getList().Where(p => p.DateOfBirth.Year == 2000).ToList();
            List<Person> greater2k = _personRepositories.getList().Where(p => p.DateOfBirth.Year > 2000).ToList();
            List<Person> lower2k = _personRepositories.getList().Where(p => p.DateOfBirth.Year < 2000).ToList();
            return (equal2k, greater2k, lower2k);
        }



        public IActionResult ExportToExcel()
        {
            var people = _personRepositories.getList(); // Lấy danh sách people từ repository


            // Tạo file Excel
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

                // Dữ liệu
                int row = 2;
                foreach (var person in people)
                {
                    worksheet.Cells[row, 1].Value = person.FirstName;
                    worksheet.Cells[row, 2].Value = person.LastName;
                    worksheet.Cells[row, 3].Value = person.Gender;
                    worksheet.Cells[row, 4].Value = person.DateOfBirth.ToString("dd/MM/yyyy");
                    worksheet.Cells[row, 5].Value = person.PhoneNumber;
                    worksheet.Cells[row, 6].Value = person.BirthPlace;
                    worksheet.Cells[row, 7].Value = person.Age;
                    worksheet.Cells[row, 8].Value = person.IsGraduated;
                    row++;
                }

                // Auto fit columns
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // Stream file Excel
                MemoryStream stream = new MemoryStream();
                excelPackage.SaveAs(stream);
                stream.Position = 0;

                // Trả về FileStreamResult để tải xuống
                return new FileStreamResult(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    FileDownloadName = "people.xlsx"
                };
            }
        }


        static bool IsUpperCaseFirstChar(string name)
        {
            return !string.IsNullOrEmpty(name) && char.IsUpper(name[0]) && name.Substring(1).ToLower() == name.Substring(1);
        }

        static bool IsContainAnyDigit(string name)
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

        static bool IsContainAllDigit(string input)
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

        public IEnumerable<Person> GetMalePersons(List<Person> people)
        {
            throw new NotImplementedException();
        }
    }


}

