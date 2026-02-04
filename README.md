# User Management System – Backend

## Overview

This is a simple User Management system built with **.NET 9** using **Clean Architecture** principles.
It provides authentication and full CRUD operations for users.

The focus of this project is on:

* Clean code structure
* SOLID principles
* Layered architecture
* Basic validation and error handling

---

## Architecture

The backend follows **Clean Architecture** with four layers:

### 1. Domain

Contains:

* Core entities
* Business rules
* Repository interfaces

### 2. Application

Contains:

* DTOs
* Use cases
* Service interfaces and implementations
* Validation logic

### 3. Infrastructure

Contains:

* EF Core DbContext
* Repository implementations
* SQL Server integration

### 4. API

Contains:

* Controllers
* Request models
* Exception handling
* Dependency injection configuration

---

## Technologies Used

* .NET 9
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* Clean Architecture
* SOLID principles

---

## Functional Features

### Authentication

* Login endpoint
* Only active users can log in
* Simple session-style login (no Identity framework)

### User Management

Full CRUD operations:

* Create user
* List users
* Update user
* Delete user

### User Fields

* Id
* Username
* Password
* UserFullName
* IsActive
* DateOfBirth
* CreationDate

---

## Prerequisites

* Visual Studio 2022 or later
* .NET 9 SDK
* SQL Server (LocalDB or full instance)

---

## How to Run the Backend

### 1. Open the Solution

Open the solution in **Visual Studio**.

### 2. Set Startup Project

Right-click:

```
UserManagement.API
```

Select:

```
Set as Startup Project
```

### 3. Configure Database

Open:

```
UserManagement.API/appsettings.json
```

Make sure the connection string is valid:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=UserManagementDb;Trusted_Connection=True;TrustServerCertificate=True"
}
```

Adjust the server name if needed.

---

### 4. Run Database Migrations

Open:

```
Tools → NuGet Package Manager → Package Manager Console
```

Set:

```
Default project: UserManagement.Infrastructure
```

Run:

```
Add-Migration InitialCreate
Update-Database
```

This will:

* Create the database
* Create the Users table

---

### 5. Run the API

Press:

```
F5
```

or click **Run**.

Swagger will open automatically.

---

## API Endpoints

### Authentication

```
POST /api/auth/login
```

Request:

```json
{
  "username": "admin",
  "password": "123"
}
```

---

### Users

#### Get All Users

```
GET /api/users
```

#### Get User by Id

```
GET /api/users/{id}
```

#### Create User

```
POST /api/users
```

Body:

```json
{
  "username": "test",
  "password": "123",
  "userFullName": "Test User",
  "dateOfBirth": "1995-01-01",
  "isActive": true
}
```

#### Update User

```
PUT /api/users
```

#### Delete User

```
DELETE /api/users/{id}
```

---

## Notes

* Passwords are stored as plain text as required by the task.
* The system is designed for clarity and structure, not UI complexity.
* Controllers are thin; business logic resides in the Application layer.

---
