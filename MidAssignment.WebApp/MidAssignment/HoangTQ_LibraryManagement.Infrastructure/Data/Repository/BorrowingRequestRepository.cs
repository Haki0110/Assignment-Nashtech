using HoangTQ_LibraryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HoangTQ_LibraryManagement.Infrastructure.Data.Repository
{
    public class BorrowingRequestRepository
    {
        private readonly LibraryContext _context;

        public BorrowingRequestRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookBorrowingRequest>> GetAllRequestsAsync()
        {
            return await _context.BookBorrowingRequests.Include(r => r.Requestor)
                .Include(r => r.BorrowingRequestDetails)
                .ThenInclude(d => d.Book).ToListAsync();
        }

        public async Task<BookBorrowingRequest> GetRequestByIdAsync(int id)
        {
            return await _context.BookBorrowingRequests.Include(r => r.Requestor)
                .Include(r => r.BorrowingRequestDetails)
                .ThenInclude(d => d.Book)
                .SingleOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddRequestAsync(BookBorrowingRequest request)
        {
            _context.BookBorrowingRequests.Add(request);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRequestAsync(BookBorrowingRequest request)
        {
            _context.BookBorrowingRequests.Update(request);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRequestAsync(BookBorrowingRequest request)
        {
            _context.BookBorrowingRequests.Remove(request);
            await _context.SaveChangesAsync();
        }
    }
}
