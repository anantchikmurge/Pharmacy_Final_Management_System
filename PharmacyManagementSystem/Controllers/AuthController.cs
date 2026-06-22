using Microsoft.AspNetCore.Mvc;
using PharmacyManagementSystem.DTO;
using PharmacyManagementSystem.Interfaces;
using Microsoft.AspNetCore.Authorization;


namespace PharmacyManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]  //AuthController must allow login and register without token(Allow Public Access)
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    // Inject the auth service so controller actions stay thin and focused on HTTP.
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    // Register a new user account.
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        var result = await _authService.RegisterAsync(registerDto);
        return Ok(result);
    }

    // Authenticate an existing user and return a JWT token.
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var result = await _authService.LoginAsync(loginDto);
        return Ok(result);
    }
}
