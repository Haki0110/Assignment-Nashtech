using HoangTQ_LibraryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoangTQ_LibraryManagement.Infrastructure.Data.Configurations
{
    public class BookBorrowingRequestDetailsConfiguration : IEntityTypeConfiguration<BookBorrowingRequestDetails>
    {
        public void Configure(EntityTypeBuilder<BookBorrowingRequestDetails> builder)
        {
            builder.HasKey(d => d.Id);
            builder.HasOne(d => d.BookBorrowingRequest).WithMany(r => r.BorrowingRequestDetails).HasForeignKey(d => d.BookBorrowingRequestId);
            builder.HasOne(d => d.Book).WithMany().HasForeignKey(d => d.BookId);
        }
    }
}
