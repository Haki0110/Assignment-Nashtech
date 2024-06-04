using HoangTQ_LibraryManagement.Domain.Entities;

namespace HoangTQ_LibraryManagement.HoangTQ_LibraryManagement.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsSuperUser { get; set; }

        public ICollection<BookBorrowingRequest> BorrowingRequests { get; set; }
    }
}
