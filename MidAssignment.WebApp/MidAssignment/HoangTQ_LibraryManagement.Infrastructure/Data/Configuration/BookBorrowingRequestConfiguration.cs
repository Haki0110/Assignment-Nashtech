using HoangTQ_LibraryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoangTQ_LibraryManagement.Infrastructure.Data.Configurations
{
    public class BookBorrowingRequestConfiguration : IEntityTypeConfiguration<BookBorrowingRequest>
    {
        public void Configure(EntityTypeBuilder<BookBorrowingRequest> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.DateRequested).IsRequired();
            builder.Property(r => r.Status).IsRequired();
            builder.HasOne(r => r.Requestor).WithMany(u => u.BorrowingRequests).HasForeignKey(r => r.RequestorId);
            builder.HasOne(r => r.Approver).WithMany().HasForeignKey(r => r.ApproverId);
        }
    }
}
