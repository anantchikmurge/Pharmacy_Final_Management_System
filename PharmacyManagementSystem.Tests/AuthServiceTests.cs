using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;
using PharmacyManagementSystem.DTO;
using PharmacyManagementSystem.Models;
using PharmacyManagementSystem.Services;

namespace PharmacyManagementSystem.Tests;

[TestFixture]
public class AuthServiceTests
{
    private Mock<UserManager<AppUser>> _userManager;
    private Mock<JwtService> _jwtService;
    private AuthService _service;

    [SetUp]
    public void Setup()
    {
        _userManager = new Mock<UserManager<AppUser>>(
            Mock.Of<IUserStore<AppUser>>(), null!, null!, null!, null!, null!, null!, null!, null!);
        _jwtService = new Mock<JwtService>(Mock.Of<Microsoft.Extensions.Configuration.IConfiguration>());
        _service = new AuthService(_userManager.Object, _jwtService.Object);
    }

    [Test]
    public async Task RegisterAsync_ReturnsSuccess()
    {
        _userManager.Setup(m => m.CreateAsync(It.IsAny<AppUser>(), It.IsAny<string>()))
                    .ReturnsAsync(IdentityResult.Success);

        var result = await _service.RegisterAsync(new RegisterDto { Email = "test@test.com", Password = "Pass@123", FullName = "Test", Role = "Doctor" });

        Assert.That(result, Is.EqualTo("User registered successfully"));
    }

    [Test]
    public async Task LoginAsync_ReturnsUserNotFound_WhenUserDoesNotExist()
    {
        _userManager.Setup(m => m.FindByEmailAsync("unknown@test.com")).ReturnsAsync((AppUser?)null);

        var result = await _service.LoginAsync(new LoginDto { Email = "unknown@test.com", Password = "Pass@123" });

        Assert.That(result, Is.EqualTo("User not found"));
    }

    [Test]
    public async Task LoginAsync_ReturnsInvalidPassword_WhenPasswordWrong()
    {
        var user = new AppUser { Email = "doc@test.com", UserName = "doc@test.com", FullName = "Doc", Role = "Doctor" };
        _userManager.Setup(m => m.FindByEmailAsync("doc@test.com")).ReturnsAsync(user);
        _userManager.Setup(m => m.CheckPasswordAsync(user, "WrongPass")).ReturnsAsync(false);

        var result = await _service.LoginAsync(new LoginDto { Email = "doc@test.com", Password = "WrongPass" });

        Assert.That(result, Is.EqualTo("Invalid password"));
    }
}
