
using ASPNETAssignment1.Models.Models;

namespace ASPNETAssignment1.Models.Repository
{
    public class PersonRepository :     IPersonRepositories
    {
        private readonly List<Person> people;

        public PersonRepository()
        {
            people = new List<Person>
            {
                new Person(1, "John", "Doe", GenderType.Male, new DateTime(2000, 5, 15), "123456789", "Someplace", "Yes"),
                new Person(2, "Alice", "Smith", GenderType.Female, new DateTime(1988, 10, 25), "123456789", "Anotherplace", "Yes"),
                new Person(3, "Michael", "Johnson", GenderType.Male, new DateTime(2000, 8, 7), "123456789", "Anyplace", "Yes"),
                new Person(4, "Emily", "Brown", GenderType.Female, new DateTime(1980, 4, 12), "123456789", "Nowhere", "Yes"),
                new Person(5, "William", "Taylor", GenderType.Male, new DateTime(2000, 7, 21), "123456789", "Everywhere", "Yes"),
                new Person(6, "Sophia", "Anderson", GenderType.Female, new DateTime(1989, 6, 5), "123456789", "Somewhere", "Yes"),
                new Person(7, "Daniel", "Martinez", GenderType.Male, new DateTime(1980, 3, 28), "123456789", "Nowhere", "Yes"),
                new Person(8, "Olivia", "Garcia", GenderType.Female, new DateTime(2001, 9, 18), "123456789", "Anotherplace", "Yes"),
                new Person(9, "Matthew", "Lopez", GenderType.Male, new DateTime(2000, 2, 9), "123456789", "Anywhere", "Yes"),
                new Person(10, "Emma", "Hernandez", GenderType.Female, new DateTime(1983, 1, 4), "123456789", "Everywhere", "Yes"),
                new Person(11, "Christopher", "Miller", GenderType.Male, new DateTime(2002, 11, 14), "123456789", "Nowhere", "Yes"),
                new Person(12, "Isabella", "Young", GenderType.Female, new DateTime(2003, 12, 30), "123456789", "Somewhere", "Yes")
            };
        }

        public IEnumerable<Person> GetAll()
        {
            return people;
        }
        public Person GetById(int id)
        {
            return people.FirstOrDefault(p => p.Id == id);
        }

        // Implementing Create method
        public void Create(Person person)
        {
            people.Add(person);
        }

        // Implementing Update method
        public void Update(Person person)
        {
            var existingPerson = people.FirstOrDefault(p => p.Id == person.Id);
            if (existingPerson != null)
            {
                existingPerson.FirstName = person.FirstName;
                existingPerson.LastName = person.LastName;
                existingPerson.Gender = person.Gender;
                existingPerson.DateOfBirth = person.DateOfBirth;
                existingPerson.PhoneNumber = person.PhoneNumber;
                existingPerson.BirthPlace = person.BirthPlace;
                existingPerson.IsGraduated = person.IsGraduated;
            }
        }


        // Implementing Delete method
        public void Delete(int id)
        {
            var personToDelete = people.FirstOrDefault(p => p.Id == id);
            if (personToDelete != null)
            {
                people.Remove(personToDelete);
            }
        }

        // Implementing GetMalePerson method
        public IEnumerable<Person> GetMalePerson(GenderType genderType)
        {
            return people.Where(p => p.Gender == genderType);
        }


    }
}