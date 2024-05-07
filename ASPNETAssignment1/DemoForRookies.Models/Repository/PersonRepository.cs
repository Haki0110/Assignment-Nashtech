
using ASPNETAssignment1.Models.Models;

namespace ASPNETAssignment1.Models.Repository
{
    public class PersonRepository : IPersonRepositories
    {
        public IEnumerable<Person> getAll()
        {
            return GetListPerson();
        }

        public IEnumerable<Person> GetListPerson()
        {
            List<Person> people = new List<Person>();

            people.Add(new Person("John", "Doe", GenderType.Male, new DateTime(2000, 5, 15), "123456789", "Someplace", "Yes"));
            people.Add(new Person("Alice", "Smith", GenderType.Female, new DateTime(1988, 10, 25), "123456789", "Anotherplace", "Yes"));
            people.Add(new Person("Michael", "Johnson", GenderType.Male, new DateTime(2000, 8, 7), "123456789", "Anyplace", "Yes"));
            people.Add(new Person("Emily", "Brown", GenderType.Female, new DateTime(1980, 4, 12), "123456789", "Nowhere", "Yes"));
            people.Add(new Person("William", "Taylor", GenderType.Male, new DateTime(2000, 7, 21), "123456789", "Everywhere", "Yes"));
            people.Add(new Person("Sophia", "Anderson", GenderType.Female, new DateTime(1989, 6, 5), "123456789", "Somewhere", "Yes"));
            people.Add(new Person("Daniel", "Martinez", GenderType.Male, new DateTime(1980, 3, 28), "123456789", "Nowhere", "Yes"));
            people.Add(new Person("Olivia", "Garcia", GenderType.Female, new DateTime(2001, 9, 18), "123456789", "Anotherplace", "Yes"));
            people.Add(new Person("Matthew", "Lopez", GenderType.Male, new DateTime(2000, 2, 9), "123456789", "Anywhere", "Yes"));
            people.Add(new Person("Emma", "Hernandez", GenderType.Female, new DateTime(1983, 1, 4), "123456789", "Everywhere", "Yes"));
            people.Add(new Person("Christopher", "Miller", GenderType.Male, new DateTime(2002, 11, 14), "123456789", "Nowhere", "Yes"));
            people.Add(new Person("Isabella", "Young", GenderType.Female, new DateTime(2003, 12, 30), "123456789", "Somewhere", "Yes"));

            return people;
        }
    }
}