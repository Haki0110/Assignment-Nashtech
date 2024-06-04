using HoangTQ_LibraryManagement.Domain.Enums;
using System;
using System.Collections.Generic;

namespace HoangTQ_LibraryManagement.Application.DTOs
{
    public class BorrowingRequestDto
    {
        public int Id { get; set; }
        public int RequestorId { get; set; }
        public string RequestorName { get; set; }
        public DateTime DateRequested { get; set; }
        public RequestStatus Status { get; set; }
        public List<BorrowingRequestDetailDto> BorrowingRequestDetails { get; set; }
    }
}
