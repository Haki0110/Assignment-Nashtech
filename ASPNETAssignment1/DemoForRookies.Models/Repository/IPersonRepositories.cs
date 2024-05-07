using ASPNETAssignment1.Models.Models;


namespace ASPNETAssignment1.Models.Repository
{
    public interface IPersonRepositories
    {
        public IEnumerable<Person> getAll();
    }
}
