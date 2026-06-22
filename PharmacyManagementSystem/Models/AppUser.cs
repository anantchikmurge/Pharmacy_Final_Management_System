using Microsoft.AspNetCore.Identity;
namespace PharmacyManagementSystem.Models;
// Represents a user in the system (Admin or Doctor)
public class AppUser : IdentityUser
{
    // Full name of the user
    public required string FullName { get; set; }

    // Role of the user (Admin / Doctor)
    public required string Role { get; set; }
}