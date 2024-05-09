using System;
using System.Collections.Generic;

namespace ASPNETAPIAssignment2.Model
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; } 

        public GenderType Gender { get; set; }
        public string BirthPlace { get; set; }

        public static List<Person> GetDummyData()
        {
            return new List<Person>
            {
                new Person { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1990, 5, 15), Gender = GenderType.Male, BirthPlace = "City1" },
                new Person { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Doe", DateOfBirth = new DateTime(1992, 8, 25), Gender = GenderType.Female, BirthPlace = "City2" },
                new Person { Id = Guid.NewGuid(), FirstName = "Alice", LastName = "Smith", DateOfBirth = new DateTime(1985, 3, 10), Gender = GenderType.Female, BirthPlace = "City3" },
                new Person { Id = Guid.NewGuid(), FirstName = "Bob", LastName = "Johnson", DateOfBirth = new DateTime(1980, 7, 20), Gender = GenderType.Male, BirthPlace = "City4" },
                new Person { Id = Guid.NewGuid(), FirstName = "Emily", LastName = "Brown", DateOfBirth = new DateTime(1995, 10, 5), Gender = GenderType.Female, BirthPlace = "City5" },
                new Person { Id = Guid.NewGuid(), FirstName = "Michael", LastName = "Wilson", DateOfBirth = new DateTime(1978, 12, 8), Gender = GenderType.Male, BirthPlace = "City6" },
                new Person { Id = Guid.NewGuid(), FirstName = "Sophia", LastName = "Martinez", DateOfBirth = new DateTime(1998, 2, 28), Gender = GenderType.Female, BirthPlace = "City7" },
                new Person { Id = Guid.NewGuid(), FirstName = "Matthew", LastName = "Taylor", DateOfBirth = new DateTime(1983, 9, 14), Gender = GenderType.Male, BirthPlace = "City8" },
                new Person { Id = Guid.NewGuid(), FirstName = "Olivia", LastName = "Thomas", DateOfBirth = new DateTime(1991, 6, 30), Gender = GenderType.Female, BirthPlace = "City9" },
                new Person { Id = Guid.NewGuid(), FirstName = "Ethan", LastName = "Anderson", DateOfBirth = new DateTime(1987, 4, 12), Gender = GenderType.Male, BirthPlace = "City10" },
                new Person { Id = Guid.NewGuid(), FirstName = "Isabella", LastName = "Jackson", DateOfBirth = new DateTime(1993, 11, 19), Gender = GenderType.Female, BirthPlace = "City11" },
                new Person { Id = Guid.NewGuid(), FirstName = "William", LastName = "White", DateOfBirth = new DateTime(1975, 1, 3), Gender = GenderType.Male, BirthPlace = "City12" },
                new Person { Id = Guid.NewGuid(), FirstName = "Mia", LastName = "Harris", DateOfBirth = new DateTime(1996, 7, 22), Gender = GenderType.Female, BirthPlace = "City13" },
                new Person { Id = Guid.NewGuid(), FirstName = "James", LastName = "Lee", DateOfBirth = new DateTime(1989, 4, 18), Gender = GenderType.Male, BirthPlace = "City14" },
                new Person { Id = Guid.NewGuid(), FirstName = "Charlotte", LastName = "Nelson", DateOfBirth = new DateTime(1982, 8, 9), Gender = GenderType.Female, BirthPlace = "City15" },
                new Person { Id = Guid.NewGuid(), FirstName = "Alexander", LastName = "Garcia", DateOfBirth = new DateTime(1994, 12, 7), Gender = GenderType.Male, BirthPlace = "City16" },
                new Person { Id = Guid.NewGuid(), FirstName = "Ava", LastName = "King", DateOfBirth = new DateTime(1986, 6, 17), Gender = GenderType.Female, BirthPlace = "City17" },
                new Person { Id = Guid.NewGuid(), FirstName = "Benjamin", LastName = "Scott", DateOfBirth = new DateTime(1981, 2, 1), Gender = GenderType.Male, BirthPlace = "City18" },
                new Person { Id = Guid.NewGuid(), FirstName = "Chloe", LastName = "Adams", DateOfBirth = new DateTime(1997, 10, 29), Gender = GenderType.Female, BirthPlace = "City19" },
                new Person { Id = Guid.NewGuid(), FirstName = "Daniel", LastName = "Roberts", DateOfBirth = new DateTime(1979, 5, 11), Gender = GenderType.Male, BirthPlace = "City20" }
            };
        }
    }
}
