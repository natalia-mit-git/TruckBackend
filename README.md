# TruckBackend

![Tests](https://github.com/natalia-mit-git/TruckBackend/actions/workflows/dotnet-tests.yml/badge.svg)

A RESTful backend service for managing trucks and their loads, built with .NET 8 and PostgreSQL.

## Features

- CRUD operations for trucks and their loads via REST API
- Persistent data storage using PostgreSQL and Entity Framework Core
- Layered architecture (Controller → Service → Data Access)
- Setup for application and database using Docker Compose
- Consistent development environment using DevContainer
- Automated tests using xUnit and EF Core InMemory provider
- CI pipeline using GitHub Actions
- API documentation via Swagger (OpenAPI)
- Database inspection via Adminer

## Tech Stack

- Runtime: .NET 8 (C#)
- ORM: Entity Framework Core
- Database: PostgreSQL
- Database tool: Adminer
- Infrastructure: Docker, Docker Compose, DevContainer
- Testing: xUnit
- API Documentation: Swagger (OpenAPI)
- CI: GitHub Actions

## Getting Started

### Using Docker
1. Clone the repository.
1. Run the following command in the root directory:
    ```bash
    docker compose up --build
    ```
1. Access the API documentation at: http://localhost:5000/swagger

### Manual Setup
1. Update the connection string in `appsettings.json`.
1. Apply database migrations:
    ```bash
    dotnet ef database update
    ```
1. Run the application:
    ```bash
    dotnet run
    ```

### Testing
Execute the test suite using the .NET CLI:
    ```bash
    dotnet test
    ```

### Database (Adminer)
- URL: http://localhost:8080
- System: PostgreSQL
- Server: postgres
- User: postgres
- Password: postgres
- Database: truckdb
