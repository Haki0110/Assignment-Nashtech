using HoangTQ_LibraryManagement.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HoangTQ_LibraryManagement.Application.Interfaces
{
    public interface IBorrowingRequestService
    {
        Task<BorrowingRequestDto> CreateBorrowingRequestAsync(BorrowingRequestDto requestDto);
        Task<BorrowingRequestDto> GetBorrowingRequestByIdAsync(int id);
        Task<IEnumerable<BorrowingRequestDto>> GetAllBorrowingRequestsAsync();
        Task<bool> ApproveBorrowingRequestAsync(int id);
        Task<bool> RejectBorrowingRequestAsync(int id);
    }
}
