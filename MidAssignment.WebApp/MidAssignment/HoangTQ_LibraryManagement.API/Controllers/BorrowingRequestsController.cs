using HoangTQ_LibraryManagement.Application.Interfaces;
using HoangTQ_LibraryManagement.Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HoangTQ_LibraryManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BorrowingRequestsController : ControllerBase
    {
        private readonly IBorrowingRequestService _borrowingRequestService;

        public BorrowingRequestsController(IBorrowingRequestService borrowingRequestService)
        {
            _borrowingRequestService = borrowingRequestService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateBorrowingRequest([FromBody] BorrowingRequestDto requestDto)
        {
            var request = await _borrowingRequestService.CreateBorrowingRequestAsync(requestDto);
            return CreatedAtAction(nameof(GetBorrowingRequestById), new { id = request.Id }, request);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBorrowingRequestById(int id)
        {
            var request = await _borrowingRequestService.GetBorrowingRequestByIdAsync(id);
            if (request == null)
                return NotFound();

            return Ok(request);
        }

        [Authorize(Roles = "SuperUser")]
        [HttpGet]
        public async Task<IActionResult> GetAllBorrowingRequests()
        {
            var requests = await _borrowingRequestService.GetAllBorrowingRequestsAsync();
            return Ok(requests);
        }

        [Authorize(Roles = "SuperUser")]
        [HttpPut("{id}/approve")]
        public async Task<IActionResult> ApproveBorrowingRequest(int id)
        {
            var result = await _borrowingRequestService.ApproveBorrowingRequestAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [Authorize(Roles = "SuperUser")]
        [HttpPut("{id}/reject")]
        public async Task<IActionResult> RejectBorrowingRequest(int id)
        {
            var result = await _borrowingRequestService.RejectBorrowingRequestAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
