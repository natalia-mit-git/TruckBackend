# TruckBackend

![Tests](https://github.com/natalia-mit-git/TruckBackend/actions/workflows/dotnet-tests.yml/badge.svg)

A RESTful backend service for truck and load management built with .NET 8 and PostgreSQL. This project demonstrates a structured approach to building web APIs with a focus on maintainability and data integrity.

## Features

- Create Trucks and their associated Loads via CRUD operations
- Relational Data Storage: Persistent storage using PostgreSQL with Entity Framework Core
- Containerized Environment: Full setup for application and database using Docker Compose
- Unit and integration tests
- CI: GitHub Actions for automated testing and release

## Tech Stack

- Runtime: .NET 8 (C#)
- ORM: Entity Framework Core
- Database: PostgreSQL
- Infrastructure: Docker, Docker Compose
- Testing: xUnit
- API Documentation: Swagger (OpenAPI)
- CI: GitHub Actions

## Getting Started

### Using Docker
1. Clone the repository.
1. Run the following command in the root directory:
```bash
docker-compose up --build
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
