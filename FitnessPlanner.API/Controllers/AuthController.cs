using FitnessPlanner.Application.DTOs;
using FitnessPlanner.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace FitnessPlanner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var result = await _authService.RegisterAsync(dto);
            if (result == null)
                return BadRequest(new { message = "User already exists." });

            return Ok(new
            {
                message = "User successfully registered.",
                user = result
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var token = await _authService.LoginAsync(dto);
            if (token == null)
                return Unauthorized(new { message = "Invalid credentials." });

            return Ok(new
            {
                token = token,
                message = "User successfully logged in."
            });
        }
    }
}