using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using PharmacyManagementSystem.Models;
using PharmacyManagementSystem.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PharmacyManagementSystem.Tests;

[TestFixture]
public class JwtServiceTests
{
    private JwtService _service;

    [SetUp]
    public void Setup()
    {
        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                { "Jwt:Key", "SuperSecretTestKeyThatIsLongEnough123!" },
                { "Jwt:Issuer", "TestIssuer" },
                { "Jwt:Audience", "TestAudience" }
            })
            .Build();

        _service = new JwtService(config);
    }

    [Test]
    public void GenerateToken_ReturnsNonEmptyToken()
    {
        var user = new AppUser { Email = "doc@test.com", UserName = "doc@test.com", FullName = "Doc", Role = "Doctor" };

        var token = _service.GenerateToken(user);

        Assert.That(token, Is.Not.Null.And.Not.Empty);
    }

    [Test]
    public void GenerateToken_ContainsRoleClaim()
    {
        var user = new AppUser { Email = "admin@test.com", UserName = "admin@test.com", FullName = "Admin", Role = "Admin" };

        var token = _service.GenerateToken(user);
        var claims = new JwtSecurityTokenHandler().ReadJwtToken(token).Claims;

        Assert.That(claims.Any(c => c.Type == ClaimTypes.Role && c.Value == "Admin"), Is.True);
    }
}
