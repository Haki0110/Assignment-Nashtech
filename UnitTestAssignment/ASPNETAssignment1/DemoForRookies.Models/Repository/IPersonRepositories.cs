using ASPNETAssignment1.Models.Models;


namespace ASPNETAssignment1.Models.Repository
{
    public interface IPersonRepositories
    {
        public IEnumerable<Person> GetAll();

        public IEnumerable<Person> GetMalePerson(GenderType genderType);

        Person GetById(int id);
        void Create(Person person);
        void Update(Person person); 
        void Delete(int id);
    }
}
