# 🏛 Clean Architecture Sample (.NET 10)

<p align="center">
  <a href="README_EN"><img alt="English" src="https://img.shields.io/badge/English-blue"></a>
  <a href="README.md"><img alt="فارسی" src="https://img.shields.io/badge/فارسی-green"></a>
</p>

[![.NET](https://img.shields.io/badge/.NET-10-purple)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/License-MIT-green)](LICENSE)
[![Architecture](https://img.shields.io/badge/Architecture-Clean-blue)](https://github.com/Soheil-Ssh/clean-architecture/tree/master)

Understanding Clean Architecture can be challenging due to the lack of a single standard implementation and the wide variety of personal approaches found across different projects.

The goal of this repository is to provide a simple yet practical implementation of Clean Architecture using modern .NET technologies and commonly used architectural patterns.

This project is intended as an educational reference for developers who want to learn how to structure maintainable and scalable applications using Clean Architecture principles.

## 📑 Table of Contents
- [🏛 Clean Architecture Sample (.NET 10)](#-clean-architecture-sample-net-10)
  - [📑 Table of Contents](#-table-of-contents)
  - [📚 What You'll Learn](#-what-youll-learn)
- [✨ Features](#-features)
  - [📋 Project Domain](#-project-domain)
  - [🏗 Project Structure](#-project-structure)
    - [1. Core Layer](#1-core-layer)
    - [2. Application Layer](#2-application-layer)
    - [3. Infrastructure Layer](#3-infrastructure-layer)
    - [4. Presentation Layer (API)](#4-presentation-layer-api)
  - [⚠️ Important Notes](#️-important-notes)
  - [🚀 Getting Started](#-getting-started)
  - [Prerequisites](#prerequisites)
    - [1. Clone and Restore](#1-clone-and-restore)
    - [2. Configure the Database](#2-configure-the-database)
    - [3. Apply Migrations](#3-apply-migrations)
    - [4. Run the Application](#4-run-the-application)


## 📚 What You'll Learn
- How to structure a solution using Clean Architecture
- How to implement CQRS for separating read and write operations
- How to apply the Repository and Unit of Work patterns
- How to implement the Result Pattern for error handling
- How to organize dependencies between architectural layers
- How to build maintainable ASP.NET Core Web APIs

# ✨ Features

This project includes the following architectural patterns and technologies:

- Clean Architecture
- CQRS (Commands & Queries)
- Repository Pattern
- Unit of Work
- Result Pattern
- FluentValidation
- Entity Framework Core
- SQL Server
- Global Exception Handling
- Scalar API Documentation
- SOLID Principles

## 📋 Project Domain

To keep the project simple, a very simple Task Manager system is considered, with ToDo as its main entity.

```csharp
public class ToDo : BaseEntity<long>
{
    public required string Title { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? CompletedDate { get; set; }
}
```

The architectural approach remains the same regardless of the underlying database technology. Switching from SQL Server to alternatives such as PostgreSQL or MongoDB would only require changes within the Infrastructure layer.

## 🏗 Project Structure

The solution is organized into the following layers:

```plaintext
Src
├── CleanArch.Api
├── CleanArch.Application
├── CleanArch.Core
└── CleanArch.Infrastructure
```

### 1. Core Layer

The Core layer represents the heart of the application and must not depend on any other layer.

It contains:

- Entities
- Domain Abstractions (such as Result Pattern and Errors)
- Specifications
- Interfaces
- Value Objects and other domain concepts

> To keep the project focused on Clean Architecture concepts, some advanced Domain-Driven Design (DDD) patterns such as Value Objects have intentionally been omitted.

### 2. Application Layer

The Application layer contains the implementation of the system's use cases and application logic.

It includes:

- Commands & Queries
- Command / Query Handlers
- Command / Query Validators
- Mapping Profiles
- Pipeline Behaviors
- DTOs

This layer depends only on the Core layer and uses the abstractions defined there.

### 3. Infrastructure Layer

The Infrastructure layer contains implementations of external services and technical concerns.

It includes:

- Repository Implementations
- Unit of Work
- Entity Framework Core
- DbContext
- External Services

This separation keeps infrastructure concerns isolated from business logic.

### 4. Presentation Layer (API)

The Presentation layer acts as the entry point to the application.

Depending on the project requirements, this layer could be implemented as a Web API, MVC application, mobile application, desktop application, or any other user-facing interface.

In this project, the Presentation layer is implemented as an ASP.NET Core Web API.

## ⚠️ Important Notes
1. To keep the project simple and focused on Clean Architecture, advanced DDD concepts such as Domain Events, Aggregate Roots, Domain Validation, and Value Objects have been intentionally omitted.
2. This project uses Controllers instead of Minimal APIs. Both approaches are valid within Clean Architecture, but Controllers were chosen for this sample.
3. Docker support has not been included in order to keep the repository focused on architectural concepts.
4. Features such as Rate Limiting, CORS, Authentication, and Authorization have intentionally been left out, as the primary goal of this project is demonstrating Clean Architecture rather than building a production-ready Web API.

## 🚀 Getting Started

## Prerequisites
- .NET 10 SDK
- SQL Server (LocalDB or a full SQL Server instance)

### 1. Clone and Restore

Clone the repository and restore NuGet packages:

```bash
dotnet restore
```

### 2. Configure the Database

Update the SQL Server connection string located in:

```bash
Src/CleanArch.Api/appsettings.json
```

### 3. Apply Migrations

Using the .NET CLI:

```bash
dotnet ef database update --project Src/CleanArch.Infrastructure --startup-project Src/CleanArch.Api
```

Using Visual Studio Package Manager Console:

```bash
Update-Database
```

Make sure the Infrastructure project is selected as the Default Project.

### 4. Run the Application

Using Visual Studio with `F5` and using .NET CLI:

```bash
dotnet run --project Src/CleanArch.Api
```

After the application starts, you can test the API endpoints using Scalar:

https://localhost:{port}/scalar