using PharmacyManagementSystem.DTO;

namespace PharmacyManagementSystem.Interfaces;

// Defines authentication operations
public interface IAuthService
{
    Task<string> RegisterAsync(RegisterDto registerDto);

    Task<string> LoginAsync(LoginDto loginDto);
}
