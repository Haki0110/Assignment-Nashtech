using HoangTQ_LibraryManagement.Application.DTOs;
using HoangTQ_LibraryManagement.Application.Interfaces;
using HoangTQ_LibraryManagement.Domain.Entities;
using HoangTQ_LibraryManagement.Domain.Enums;
using HoangTQ_LibraryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoangTQ_LibraryManagement.Application.Services
{
    public class BorrowingRequestService : IBorrowingRequestService
    {
        private readonly LibraryContext _context;

        public BorrowingRequestService(LibraryContext context)
        {
            _context = context;
        }

        public async Task<BorrowingRequestDto> CreateBorrowingRequestAsync(BorrowingRequestDto requestDto)
        {
            var request = new BookBorrowingRequest
            {
                RequestorId = requestDto.RequestorId,
                DateRequested = requestDto.DateRequested,
                Status = RequestStatus.Waiting,
                BorrowingRequestDetails = requestDto.BorrowingRequestDetails.Select(d => new BookBorrowingRequestDetails
                {
                    BookId = d.BookId
                }).ToList()
            };

            _context.BookBorrowingRequests.Add(request);
            await _context.SaveChangesAsync();

            requestDto.Id = request.Id;
            return requestDto;
        }

        public async Task<BorrowingRequestDto> GetBorrowingRequestByIdAsync(int id)
        {
            var request = await _context.BookBorrowingRequests
                .Include(r => r.Requestor)
                .Include(r => r.BorrowingRequestDetails).ThenInclude(d => d.Book)
                .SingleOrDefaultAsync(r => r.Id == id);

            if (request == null)
                return null;

            return new BorrowingRequestDto
            {
                Id = request.Id,
                RequestorId = request.RequestorId,
                RequestorName = request.Requestor.Username,
                DateRequested = request.DateRequested,
                Status = request.Status,
                BorrowingRequestDetails = request.BorrowingRequestDetails.Select(d => new BorrowingRequestDetailDto
                {
                    Id = d.Id,
                    BookId = d.BookId,
                    BookTitle = d.Book.Title
                }).ToList()
            };
        }

        public async Task<IEnumerable<BorrowingRequestDto>> GetAllBorrowingRequestsAsync()
        {
            return await _context.BookBorrowingRequests
                .Include(r => r.Requestor)
                .Include(r => r.BorrowingRequestDetails).ThenInclude(d => d.Book)
                .Select(r => new BorrowingRequestDto
                {
                    Id = r.Id,
                    RequestorId = r.RequestorId,
                    RequestorName = r.Requestor.Username,
                    DateRequested = r.DateRequested,
                    Status = r.Status,
                    BorrowingRequestDetails = r.BorrowingRequestDetails.Select(d => new BorrowingRequestDetailDto
                    {
                        Id = d.Id,
                        BookId = d.BookId,
                        BookTitle = d.Book.Title
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<bool> ApproveBorrowingRequestAsync(int id)
        {
            var request = await _context.BookBorrowingRequests.FindAsync(id);
            if (request == null)
                return false;

            request.Status = RequestStatus.Approved;

            _context.BookBorrowingRequests.Update(request);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RejectBorrowingRequestAsync(int id)
        {
            var request = await _context.BookBorrowingRequests.FindAsync(id);
            if (request == null)
                return false;

            request.Status = RequestStatus.Rejected;

            _context.BookBorrowingRequests.Update(request);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
