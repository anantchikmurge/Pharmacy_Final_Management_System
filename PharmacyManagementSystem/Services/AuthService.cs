using Microsoft.AspNetCore.Identity;
using PharmacyManagementSystem.DTO;
using PharmacyManagementSystem.Interfaces;
using PharmacyManagementSystem.Models;
using PharmacyManagementSystem.Services;

namespace PharmacyManagementSystem.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly JwtService _jwtService;

    // UserManager handles ASP.NET Identity persistence, password hashing, and validation.
    public AuthService(UserManager<AppUser> userManager, JwtService jwtService)
    {
        _userManager = userManager;
        _jwtService = jwtService;
    }

    // Create a new identity user record in the AspNetUsers table.
    public async Task<string> RegisterAsync(RegisterDto registerDto)
    {
        var user = new AppUser
        {
            UserName = registerDto.Email,
            Email = registerDto.Email,
            FullName = registerDto.FullName,
            Role = registerDto.Role
        };

        var result = await _userManager.CreateAsync(user, registerDto.Password);

        if (!result.Succeeded)
        {
            return string.Join("; ", result.Errors.Select(error => error.Description));
        }

        return "User registered successfully";
    }

    // Validate the supplied credentials and return a signed JWT for valid users.
    public async Task<string> LoginAsync(LoginDto loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email);

        if (user == null)
        {
            return "User not found";
        }

        var passwordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);

        if (!passwordValid)
        {
            return "Invalid password";
        }

        var token = _jwtService.GenerateToken(user);

        return token;
    }
}
