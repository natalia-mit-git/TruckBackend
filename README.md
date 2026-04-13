# TruckBackend

![Tests](https://github.com/natalia-mit-git/TruckBackend/actions/workflows/dotnet-tests.yml/badge.svg)

A RESTful backend service for managing trucks and their loads, built with .NET 8 and PostgreSQL.

## Features

- CRUD operations for trucks and their loads via REST API
- Persistent data storage using PostgreSQL and Entity Framework Core
- Layered architecture (Controller → Service → Data Access)
- Docker Compose setup for development and production environments
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

### Run with Docker (Recommended)
1. Clone the repository
1. Start the application and database:
    ```bash
    docker compose up --build
    ```

### Development (DevContainer)
1. Clone the repository
1. Create a `.env` file inside the `.devcontainer` folder or set the environment variables:
    ```bash
    POSTGRES_USER, POSTGRES_PASSWORD, POSTGRES_DB
    ```
    The values should match the PostgreSQL credentials shown in the [Access](#access) section below.
1. Open the project in VS Code and select:
    ```bash
    Dev Containers: Rebuild Container
    ```
1. Run the application inside the container:
    ```bash
    dotnet watch run
    ```

### Access
Available in both docker and development modes.
1. Access the API documentation at: http://localhost:5000/swagger
1. Inspect the database via Adminer at http://localhost:8080
- System: PostgreSQL
- Server: postgres
- User: postgres
- Password: postgres
- Database: truckdb

### Testing
- Tests are executed automatically via GitHub Actions
- Run locally :
    ```bash
    dotnet test
    ```
