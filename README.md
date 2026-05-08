# 🛒 ECommerce API

A production-ready REST API built with **Clean Architecture**, **CQRS Pattern**, and **Docker** support.

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp)
![SQLite](https://img.shields.io/badge/SQLite-003B57?style=for-the-badge&logo=sqlite)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker)
![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)

---

## 📋 Overview

ECommerce API is a backend service for managing products and orders in an e-commerce platform. Built with industry best practices including Clean Architecture, CQRS pattern, and containerization with Docker.

### ✨ Features

- ✅ **Product Management** – Create, read, update, and delete products
- ✅ **Order Management** – Place and track orders with order items
- ✅ **Clean Architecture** – Strict separation of concerns across 4 layers
- ✅ **CQRS Pattern** – Commands and queries are fully separated
- ✅ **Entity Framework Core** – Code-first migrations with SQLite
- ✅ **Docker Support** – Fully containerized, runs anywhere
- ✅ **Swagger UI** – Interactive API documentation

---

## 🏗️ Architecture

This project follows **Clean Architecture** principles. Dependencies always point inward.

```
┌─────────────────────────────────┐
│         API Layer               │  Controllers, DTOs, Program.cs
├─────────────────────────────────┤
│      Application Layer          │  Commands, Queries, Handlers
├─────────────────────────────────┤
│       Domain Layer              │  Entities, Interfaces (no dependencies)
├─────────────────────────────────┤
│    Infrastructure Layer         │  DbContext, Repositories
└─────────────────────────────────┘
```

### Project Structure

```
ECommerceAPI/
├── ECommerceAPI.API/                  # Entry point – Controllers, DTOs
│   ├── Controllers/
│   │   └── ProductsController.cs
│   ├── Program.cs
│   └── Dockerfile
│
├── ECommerceAPI.Application/          # Business logic – Commands, Queries
│   ├── Commands/
│   │   ├── CreateProductCommand.cs
│   │   ├── DeleteProductCommand.cs
│   │   └── Handlers/
│   ├── Queries/
│   │   ├── GetAllProductsQuery.cs
│   │   ├── GetProductByIdQuery.cs
│   │   └── Handlers/
│   └── DTOs/
│
├── ECommerceAPI.Domain/               # Core – Entities, Interfaces
│   ├── Entities/
│   │   ├── Product.cs
│   │   ├── Order.cs
│   │   └── OrderItem.cs
│   └── Interfaces/
│       ├── IProductRepository.cs
│       └── IOrderRepository.cs
│
└── ECommerceAPI.Infrastructure/       # Data access – EF Core, Repositories
    ├── Data/
    │   └── AppDbContext.cs
    └── Repositories/
        ├── ProductRepository.cs
        └── OrderRepository.cs
```

---

## 🚀 Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop) _(optional)_

### Option 1 – Run Locally

```bash
# Clone the repository
git clone https://github.com/MahmoudAdas-Dev/ECommerceAPI.git
cd ECommerceAPI

# Run the API
dotnet run --project ECommerceAPI.API
```

Open your browser at: **http://localhost:5000/swagger**

### Option 2 – Run with Docker 🐳

```bash
# Build the image
docker build -t ecommerce-api -f ECommerceAPI.API/Dockerfile .

# Run the container without data persistence
docker run -p 8080:8080 -e ASPNETCORE_ENVIRONMENT=Development ecommerce-api



```

## 🐳 Docker

### Run with data persistence (recommended)

```bash
docker run -p 8080:8080 \
  -e ASPNETCORE_ENVIRONMENT=Development \
  -v ecommerce-data:/app \
  ecommerce-api
```

> ⚠️ Without a volume, data is lost when the container stops.
> Use `-v ecommerce-data:/app` to persist the SQLite database.

Open your browser at: **http://localhost:8080/swagger**

````


---

## 📡 API Endpoints

### Products

| Method   | Endpoint             | Description          |
| -------- | -------------------- | -------------------- |
| `GET`    | `/api/products`      | Get all products     |
| `GET`    | `/api/products/{id}` | Get product by ID    |
| `POST`   | `/api/products`      | Create a new product |
| `DELETE` | `/api/products/{id}` | Delete a product     |

### Example Request – Create Product

```http
POST /api/products
Content-Type: application/json

{
  "name": "Gaming Laptop",
  "description": "High performance laptop for gaming",
  "price": 999.99,
  "stock": 10
}
````

### Example Response

```json
{
  "id": 1,
  "name": "Gaming Laptop",
  "description": "High performance laptop for gaming",
  "price": 999.99,
  "stock": 10
}
```

---

## 🧱 Design Patterns

### CQRS (Command Query Responsibility Segregation)

Every operation is its own class:

```
CreateProductCommand   → changes data  (POST)
DeleteProductCommand   → changes data  (DELETE)
GetAllProductsQuery    → reads data    (GET)
GetProductByIdQuery    → reads data    (GET)
```

### Repository Pattern

Data access is abstracted behind interfaces:

```csharp
// Domain defines the contract
public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<Product> AddAsync(Product product);
    Task DeleteAsync(int id);
}

// Infrastructure implements it
public class ProductRepository : IProductRepository { ... }
```

### Dependency Injection

All dependencies are injected via constructor – no hard-coded dependencies:

```csharp
public class CreateProductCommandHandler
{
    private readonly IProductRepository _repository;

    public CreateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository; // injected, not created
    }
}
```

---

## 🛠️ Tech Stack

| Technology            | Purpose           |
| --------------------- | ----------------- |
| ASP.NET Core 10       | Web framework     |
| Entity Framework Core | ORM & migrations  |
| SQLite                | Database          |
| Mapster               | Object mapping    |
| Swagger / Swashbuckle | API documentation |
| Docker                | Containerization  |
| xUnit                 | Unit testing      |

---

## 🧪 Running Tests

```bash
cd ECommerceAPI.Tests
dotnet test
```

---

## 📄 License

This project is licensed under the MIT License.

---

## 👤 Author

**Mahmoud Adas**

- GitHub: [@MahmoudAdas-Dev](https://github.com/MahmoudAdas-Dev)
- LinkedIn: [Mahmoud Adas](https://www.linkedin.com/in/mahmoudadas)
