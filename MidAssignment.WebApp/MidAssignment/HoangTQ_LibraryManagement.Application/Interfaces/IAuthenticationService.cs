using System.Threading.Tasks;

namespace HoangTQ_LibraryManagement.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> AuthenticateAsync(string username, string password);
    }
}
