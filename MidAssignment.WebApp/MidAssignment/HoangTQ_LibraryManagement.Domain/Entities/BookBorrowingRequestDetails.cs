namespace HoangTQ_LibraryManagement.Domain.Entities
{
    public class BookBorrowingRequestDetails
    {
        public int Id { get; set; }
        public int BookBorrowingRequestId { get; set; }
        public BookBorrowingRequest BookBorrowingRequest { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
