using System;
using System.Text;
class Program{
    static void Main(string[] args)
{
    System.Console.WriteLine("Assignment 1 - Thai Quoc Hoang");
    System.Console.WriteLine("------------------------------------------------");
    System.Console.WriteLine("Step 1: Add Person Data");
    List<Person> persons = AddPerson();

do {
    System.Console.WriteLine("\nNASHTECH ROOKIE TO ENGINEER \n Application Console for Assignment 1");
    System.Console.WriteLine("------------------------------------------------");
    System.Console.WriteLine("1. List of Member who are Male");
    System.Console.WriteLine("2. The oldest Person");
    System.Console.WriteLine("3. Return full Name");
    System.Console.WriteLine("4. Return lists of member who has birthyear is 2000, greater than 2000 and less than 2000");
    System.Console.WriteLine("5. Return the first person born in Hanoi");
    System.Console.WriteLine("------------------------------------------------");
    System.Console.Write("Your choice: ");
    int choice;
    if (int.TryParse(Console.ReadLine(), out choice)) {
        switch (choice) {
            case 1:
                System.Console.WriteLine(ListMalePerson(persons));
                break;
            case 2:
                System.Console.WriteLine(GetOldestPerson(persons));
                break;
            case 3:
                System.Console.WriteLine(GetFullName(persons));
                break;
            case 4:
                System.Console.WriteLine(GetInfoBirthAround2k(persons));
                break;
            case 5:
                System.Console.WriteLine(GetFirstPersonBornInHanoi(persons));
                break;
            default:
                System.Console.WriteLine("Invalid choice! Please try again.");
                break;
        }
    } else {
        System.Console.WriteLine("Invalid input! Please enter a number.");
    }
    System.Console.WriteLine("\nDo you want to continue? (Y/N)");
} while (Console.ReadLine().Equals("Y", StringComparison.OrdinalIgnoreCase));
}

static string ListMalePerson(List<Person> people)
{
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append("The list of people who are Male shown below: \n");
    stringBuilder.Append($"{"First Name",-15} {"Last Name",-15} {"Gender",-10} {"Date Of Birth",-15} {"Phone Number",-15} {"Birthplace",-15} {"Age",-10} {"Is Guaranted",-1}\n");

    var malePeople = people.Where(person => string.Equals(person.Gender, "male", StringComparison.CurrentCultureIgnoreCase));

    foreach (var person in malePeople)
    {
        stringBuilder.Append($"{person.FirstName,-15} {person.LastName,-15} {person.Gender,-10} {person.DateOfBirth.ToString("dd/MM/yyyy"),-15} {person.PhoneNumber,-15} {person.BirthPlace,-15} {person.Age,-10} {person.IsGraduated,-1}\n");
    }

    return stringBuilder.ToString();
}

static string GetOldestPerson(List<Person> people){
       StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append("The list of people who are the oldest person shown below: \n");
    stringBuilder.Append($"{"First Name", -15} {"Last Name", -15} {"Gender", -10} {"Date Of Birth", -15} {"Phone Number", -15} {"Birthplace", -15} {"Age", -10} {"Is Guaranted", -1}\n");
    var oldestPerson = people.OrderByDescending(person => person.Age).FirstOrDefault();
    stringBuilder.Append($"{oldestPerson.FirstName, -15} {oldestPerson.LastName, -15} {oldestPerson.Gender, -10} {oldestPerson.DateOfBirth.ToString("dd/MM/yyyy"), -15} {oldestPerson.PhoneNumber, -15} {oldestPerson.BirthPlace, -15} {oldestPerson.Age, -10} {oldestPerson.IsGraduated, -1}\n");
    return stringBuilder.ToString();
}

static string GetFullName(List<Person> people){
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append("The list of people with their full name shown below: \n");
    stringBuilder.Append($"{"First Name", -15} {"Last Name", -20} {"Full Name", -20}\n");
    var getAll = people.ToList();
    foreach(Person person in getAll){
        stringBuilder.Append($"{person.FirstName, -15} {person.LastName, -20} {person.FirstName + " " + person.LastName, -20}\n");
    }
    return stringBuilder.ToString();
}

static string GetInfoBirthAround2k(List<Person> people){
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append("The list of people who has birthdate's year is 2000 shown below: \n");
    stringBuilder.Append($"{"First Name", -15} {"Last Name", -15} {"Gender", -10} {"Date Of Birth", -15} {"Phone Number", -15} {"Birthplace", -15} {"Age", -10} {"Is Guaranted", -1}\n");
    var resultEqual2000 = people.Where(p => p.DateOfBirth.Year == 2000);
    var resultGreater2000 = people.Where(p => p.DateOfBirth.Year > 2000);
    var resultLower = people.Where(p => p.DateOfBirth.Year < 2000);
    
    foreach (Person person in resultEqual2000) {
        if (person.DateOfBirth.Year == 2000){
        stringBuilder.Append($"{person.FirstName, -15} {person.LastName, -15} {person.Gender, -10} {person.DateOfBirth.ToString("dd/MM/yyyy"), -15} {person.PhoneNumber, -15} {person.BirthPlace, -15} {person.Age, -10} {person.IsGraduated, -1}\n");
        }
    }

    stringBuilder.Append("\nThe list of people who has birthdate's year greater than 2000 shown below: \n");
    stringBuilder.Append($"{"First Name", -15} {"Last Name", -15} {"Gender", -10} {"Date Of Birth", -15} {"Phone Number", -15} {"Birthplace", -15} {"Age", -10} {"Is Guaranted", -1}\n");
    foreach (Person person in resultGreater2000){
        if (person.DateOfBirth.Year > 2000){
    stringBuilder.Append($"{person.FirstName, -15} {person.LastName, -15} {person.Gender, -10} {person.DateOfBirth.ToString("dd/MM/yyyy"), -15} {person.PhoneNumber, -15} {person.BirthPlace, -15} {person.Age, -10} {person.IsGraduated, -1}\n");
        }
    }

    stringBuilder.Append("\nThe list of people who has birthdate's year lower than 2000 shown below: \n");
    stringBuilder.Append($"{"First Name", -15} {"Last Name", -15} {"Gender", -10} {"Date Of Birth", -15} {"Phone Number", -15} {"Birthplace", -15} {"Age", -10} {"Is Guaranted", -1}\n");
    foreach (Person person in resultLower){
    if (person.DateOfBirth.Year < 2000){
    stringBuilder.Append($"{person.FirstName, -15} {person.LastName, -15} {person.Gender, -10} {person.DateOfBirth.ToString("dd/MM/yyyy"), -15} {person.PhoneNumber, -15} {person.BirthPlace, -15} {person.Age, -10} {person.IsGraduated, -1}\n");
        }
    }
    return stringBuilder.ToString();
}

static string GetFirstPersonBornInHanoi(List<Person> people){
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append("The first person who was born in Hanoi shown below: \n");
    stringBuilder.Append($"{"First Name", -15} {"Last Name", -15} {"Gender", -10} {"Date Of Birth", -15} {"Phone Number", -15} {"Birthplace", -15} {"Age", -10} {"Is Guaranted", -1}\n");
    var firstBornHN = people.Where(p => string.Equals(p.BirthPlace, "hanoi", StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
    
            stringBuilder.Append($"{firstBornHN.FirstName, -15} {firstBornHN.LastName, -15} {firstBornHN.Gender, -10} {firstBornHN.DateOfBirth.ToString("dd/MM/yyyy"), -15} {firstBornHN.PhoneNumber, -15} {firstBornHN.BirthPlace, -15} {firstBornHN.Age, -10} {firstBornHN.IsGraduated, -1}\n");
    
    
    return stringBuilder.ToString();
}

static List<Person> AddPerson(){
System.Console.Write("Enter the number of people you want to add: ");
    int numberOfPeople;
    while (!int.TryParse(Console.ReadLine(), out numberOfPeople) || numberOfPeople <= 0){
        System.Console.WriteLine("Invalid number of people input!!! Please retype: ");
    };

System.Console.WriteLine("------------------------------------------------");
    List<Person> peopleList = new List<Person>();
    for(int i = 0; i < numberOfPeople; i++){
        string orderOfPerson;
        if(i % 10 == 0){
            orderOfPerson = $"{i+1}st";
        } else if(i % 10 == 1){
            orderOfPerson = $"{i+1}nd";
        } else orderOfPerson = $"{i+1}rd";

        Person person = new Person();
        System.Console.WriteLine($"Please enter data of {orderOfPerson} people!");
        System.Console.Write("First Name: ");
        string firstNameCheck = Console.ReadLine();
        while(!ValidateName(firstNameCheck)){
            System.Console.WriteLine("Invalid First Name! Please Retype");
            System.Console.Write("First Name: ");
            firstNameCheck = Console.ReadLine();
        }
        person.FirstName = firstNameCheck;
        
        System.Console.Write("Last Name: ");
        string lastNameCheck = Console.ReadLine();
        while(!ValidateName(lastNameCheck)){
            System.Console.WriteLine("Invalid Last Name! Please Retype");
            System.Console.Write("Last Name: ");
            lastNameCheck = Console.ReadLine();
        }
        person.LastName = lastNameCheck;

        System.Console.Write("Gender: ");
        string genderCheck = Console.ReadLine();
        while(!ValidateGender(genderCheck)){
            System.Console.WriteLine("Invalid Gender! Please Retype");
            System.Console.Write("Gender: ");
            genderCheck = Console.ReadLine();
        }
        person.Gender = genderCheck;

        System.Console.Write("Date Of Birth (dd/MM/yyyy): ");
        DateTime dateCheck;
        while(!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dateCheck)){
            System.Console.WriteLine("Invalid Date of Birth input, please Retype in format (dd/MM/yyyy)");
        }
        person.DateOfBirth = dateCheck;

        System.Console.Write("Phone Number: ");
        string checkPhoneNumber = Console.ReadLine();
        while(!IsContainAllDigit(checkPhoneNumber)){
            System.Console.WriteLine("Invalid Phone Number, please retype");
            System.Console.Write("Phone Number: ");
            checkPhoneNumber = Console.ReadLine();
        }
        person.PhoneNumber = checkPhoneNumber;

        System.Console.Write("Birthplace: ");
        string checkBirthplace = Console.ReadLine();
        while(string.IsNullOrEmpty(checkBirthplace)){
            System.Console.WriteLine("Invalid Birth Place, please retype");
            System.Console.Write("Birthplace: ");
            checkBirthplace = Console.ReadLine();
        }
        person.BirthPlace = checkBirthplace;

        DateTime present = DateTime.Today;
        person.Age = present.Year - person.DateOfBirth.Year;

        System.Console.Write("Is Graduated (Yes/No): ");
        string graduateStatus = Console.ReadLine(); 
        while(!ValidateGraduated(graduateStatus) && string.IsNullOrEmpty(graduateStatus)){
            System.Console.WriteLine("Invalid Graduated Status! Please Retype");
        }
        if (string.Equals(graduateStatus, "yes", StringComparison.CurrentCultureIgnoreCase)){
            person.IsGraduated = "Yes";
        } else person.IsGraduated = "No";
        peopleList.Add(person);
        System.Console.WriteLine("------------------------------------------------");
    }
    return peopleList;
}

static bool ValidateName(string name){
    return !IsContainAnyDigit(name) && IsUpperCaseFirstChar(name) && !string.IsNullOrWhiteSpace(name);
}

static bool IsUpperCaseFirstChar(string name){
    return !string.IsNullOrEmpty(name) && char.IsUpper(name[0]) && name.Substring(1).ToLower() == name.Substring(1);
}

static bool IsContainAnyDigit(string name){
    foreach (char c in name){
        if(char.IsDigit(c)){
            return true;
        }
    }
    return false;
}

static bool IsContainAllDigit(string input){
    foreach (char c in input){
        if(!char.IsDigit(c)){
            return false;
        }
    }
    return true;
}

static bool ValidateGender(string gender){
    if(gender.ToLower().Equals("male") || gender.ToLower().Equals("female") && !string.IsNullOrWhiteSpace(gender)){
        return true;
    }
    return false;
}

static bool ValidateGraduated(string gender){
    if(gender.ToLower().Equals("yes") && gender.ToLower().Equals("no") && string.IsNullOrWhiteSpace(gender)){
        return true;
    }
    return false;
}
}




