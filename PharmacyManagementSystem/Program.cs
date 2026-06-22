using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using PharmacyManagementSystem.Data;
using PharmacyManagementSystem.Interfaces;
using PharmacyManagementSystem.Repositories;
using PharmacyManagementSystem.Services;
using PharmacyManagementSystem.Models;
using PharmacyManagementSystem.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Database connection
builder.Services.AddDbContext<PharmacyDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity configuration
builder.Services.AddIdentity<AppUser, IdentityRole>()
.AddEntityFrameworkStores<PharmacyDbContext>();

// Repositories
builder.Services.AddScoped<IDrugRepository, DrugRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

// Services Registration
builder.Services.AddScoped<IDrugService, DrugService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<JwtService>();
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));

builder.Services.AddControllers();

// Swagger configuration with JWT support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
{
Name = "Authorization",
Type = SecuritySchemeType.Http,
Scheme = "bearer",
BearerFormat = "JWT",
In = ParameterLocation.Header,
Description = "Enter token like: Bearer {your JWT token}"
});

options.AddSecurityRequirement(new OpenApiSecurityRequirement
{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[] {}
    }
});

});

// JWT Authentication
var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!);

builder.Services.AddAuthentication(options =>
{
options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
options.TokenValidationParameters = new TokenValidationParameters
{
ValidateIssuer = true,
ValidateAudience = true,
ValidateLifetime = true,
ValidateIssuerSigningKey = true,
RoleClaimType=ClaimTypes.Role,
NameClaimType=ClaimTypes.Name,

    ValidIssuer = builder.Configuration["Jwt:Issuer"],
    ValidAudience = builder.Configuration["Jwt:Audience"],
    IssuerSigningKey = new SymmetricSecurityKey(key)
};

});

var app = builder.Build();

// Swagger in development
if (app.Environment.IsDevelopment())
{
app.UseSwagger();
app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();