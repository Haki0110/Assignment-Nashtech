using HoangTQ_LibraryManagement.Application.Interfaces;
using HoangTQ_LibraryManagement.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HoangTQ_LibraryManagement.HoangTQ_LibraryManagement.Application.DTOs;

namespace HoangTQ_LibraryManagement.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthenticationController : ControllerBase
	{
		private readonly IAuthenticationService _authenticationService;

		public AuthenticationController(IAuthenticationService authenticationService)
		{
			_authenticationService = authenticationService;
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
		{
			var token = await _authenticationService.AuthenticateAsync(loginDto.Username, loginDto.Password);
			if (token == null)
				return Unauthorized("Invalid credentials");

			return Ok(new { Token = token });
		}
	}
}
