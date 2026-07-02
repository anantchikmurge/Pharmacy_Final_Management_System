# Pharmacy Management System

A REST API built with ASP.NET Core for managing pharmacy operations including drugs, orders, suppliers, and sales.

## Tech Stack

- **Backend:** ASP.NET Core 10
- **Database:** SQL Server + Entity Framework Core
- **Authentication:** ASP.NET Identity + JWT
- **Testing:** NUnit + Moq
- **API Docs:** Swagger UI

## Roles

| Role | Permissions |
|------|-------------|
| Admin | Full access — manage drugs, suppliers, orders, sales |
| Doctor | View drugs, place orders, view orders |

## Project Structure

```
PharmacyManagementSystem/         # Main API project
├── Controllers/                  # API endpoints
├── Services/                     # Business logic
├── Repositories/                 # Data access
├── Models/                       # Entity models
├── DTO/                          # Data transfer objects
├── Interfaces/                   # Abstractions
├── Middleware/                   # Exception handling
└── Data/                         # DbContext

PharmacyManagementSystem.Tests/   # Unit tests (NUnit + Moq)
```

## API Endpoints

### Auth
| Method | Endpoint | Access |
|--------|----------|--------|
| POST | /api/auth/register | Public |
| POST | /api/auth/login | Public |

### Drugs
| Method | Endpoint | Access |
|--------|----------|--------|
| GET | /api/drug | Admin, Doctor |
| GET | /api/drug/{id} | Admin, Doctor |
| POST | /api/drug | Admin |
| PUT | /api/drug/{id} | Admin |
| DELETE | /api/drug/{id} | Admin |

### Orders
| Method | Endpoint | Access |
|--------|----------|--------|
| GET | /api/order | Admin, Doctor |
| POST | /api/order | Doctor |
| PUT | /api/order/approve/{id} | Admin |

### Suppliers
| Method | Endpoint | Access |
|--------|----------|--------|
| GET | /api/supplier | Admin |
| POST | /api/supplier | Admin |
| PUT | /api/supplier/{id} | Admin |
| DELETE | /api/supplier/{id} | Admin |

### Sales
| Method | Endpoint | Access |
|--------|----------|--------|
| GET | /api/sale | Admin |
| POST | /api/sale | Admin |

## Getting Started

### 1. Clone the repo
```bash
git clone https://github.com/anantchikmurge/Pharmacy_Final_Management_System.git
cd Pharmacy_Final_Management_System
```

### 2. Configure appsettings.json
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "your-sql-server-connection-string"
  },
  "Jwt": {
    "Key": "your-secret-key",
    "Issuer": "PharmacyAPI",
    "Audience": "PharmacyUsers"
  },
  "SmtpSettings": {
    "Host": "smtp.gmail.com",
    "Port": 587,
    "Username": "your-email",
    "Password": "your-app-password"
  }
}
```

### 3. Apply migrations
```bash
dotnet ef database update
```

### 4. Run the project
```bash
dotnet run
```
Swagger opens at `http://localhost:5167`

## Running Tests
```bash
cd PharmacyManagementSystem.Tests
dotnet test
```
