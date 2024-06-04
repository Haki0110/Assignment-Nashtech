using HoangTQ_LibraryManagement.Domain.Enums;
using HoangTQ_LibraryManagement.HoangTQ_LibraryManagement.Domain.Entities;

namespace HoangTQ_LibraryManagement.Domain.Entities
{
    public class BookBorrowingRequest
    {
        public int Id { get; set; }
        public int RequestorId { get; set; }
        public User Requestor { get; set; }
        public DateTime DateRequested { get; set; }
        public RequestStatus Status { get; set; } // Approved, Rejected, Waiting
        public int? ApproverId { get; set; }
        public User Approver { get; set; }
        public ICollection<BookBorrowingRequestDetails> BorrowingRequestDetails { get; set; }
    }
}
