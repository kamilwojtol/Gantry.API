# Gantry.API

Backend REST API for **Gantry** — a team collaboration application built around a Kanban board.

The project was created to practice building a backend application with **ASP.NET Core, C#, Entity Framework Core and SQL Server**, including REST API design, dependency injection, service-layer architecture and database access.

## 🚀 Live Demo

The API is deployed and publicly accessible:

**[Open Gantry API](https://gantry-btaedmegevfabtdp.westcentralus-01.azurewebsites.net/)**

> The API is designed to work with the Gantry frontend application.

## 🖥️ Frontend

The backend is part of a full-stack application.

**Frontend:** React / Next.js  
**Backend:** ASP.NET Core Web API

The frontend communicates with this API to manage Kanban boards and tasks.

## ✨ Features

- Create and manage Kanban boards
- Manage tasks within Kanban boards
- Change task status
- Retrieve tasks and boards through REST endpoints
- Persist application data using SQL Server
- Separate API, service and data-access responsibilities
- Dependency Injection
- CORS configuration for frontend communication

## 🛠️ Tech Stack

### Backend

- **C#**
- **.NET 10**
- **ASP.NET Core Web API**
- **Entity Framework Core 10**
- **SQL Server**
- REST API
- Dependency Injection
- LINQ

### Frontend

- React
- Next.js
- TypeScript

### Deployment

- Microsoft Azure

## 🏗️ Project Structure

The application separates HTTP handling, business logic and data access into different layers.

```text
Gantry.API/
├── Controllers/
│   └── API endpoints and HTTP request handling
│
├── Services/
│   └── Business logic
│
├── Interfaces/
│   └── Service abstractions
│
├── Data/
│   └── Entity Framework Core DbContext
│
├── Store/
│   └── Application data/store
│
├── Models/
│   └── Application models
│
├── Program.cs
│   └── Application configuration and dependency injection
│
└── appsettings.json
    └── Application configuration
```

The main application dependencies are registered through ASP.NET Core's built-in Dependency Injection container.

For example:

```csharp
builder.Services.AddDbContext<AppDbContext>(...);

builder.Services.AddSingleton<GantryStore>();

builder.Services.AddScoped<ITaskService, TaskService>();
```

This keeps controllers focused on HTTP-related responsibilities while application logic can be handled by dedicated services.

## 🔌 API

The API exposes endpoints for working with Kanban boards and their tasks.

Example endpoint:

```http
GET /api/kanban/{kanbanId}/tasks/{taskId}
```

Changing a task status:

```http
PATCH /api/kanban/{kanbanId}/changeTaskStatus/{taskId}?statusCode={statusCode}
```

The API is consumed by the Gantry frontend application.

## 💻 Running Locally

### Requirements

- .NET 10 SDK
- SQL Server
- Git

### 1. Clone the repository

```bash
git clone https://github.com/kamilwojtol/Gantry.API.git

cd Gantry.API
```

### 2. Configure the database

Create your local SQL Server database and provide the connection string in:

```text
Gantry.API/appsettings.json
```

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "YOUR_CONNECTION_STRING"
  }
}
```

Do not commit credentials or production connection strings to the repository.

### 3. Restore dependencies

```bash
dotnet restore
```

### 4. Apply Entity Framework migrations

```bash
dotnet ef database update
```

### 5. Run the application

```bash
dotnet run
```

The API will then be available locally on the URL displayed by ASP.NET Core.

## 🎯 What I Practiced

This project was primarily a practical exercise in backend development with the .NET ecosystem.

While building it, I focused on:

- Designing REST API endpoints
- Working with ASP.NET Core controllers
- Dependency Injection and service abstractions
- Entity Framework Core
- SQL Server integration
- Asynchronous programming with `Task`
- LINQ and collection manipulation
- Separation of responsibilities
- CORS and frontend/backend communication
- Deploying an ASP.NET Core application to Azure

## 📚 What I Learned

The project helped me better understand how a typical ASP.NET Core application is structured and how different application layers communicate with each other.

One of the main goals was to move beyond simply writing controller endpoints and understand the responsibilities of:

```text
HTTP Request
     ↓
Controller
     ↓
Service
     ↓
Data Access
     ↓
SQL Server
```

This structure makes the application easier to maintain and provides clear boundaries between HTTP handling, business logic and persistence.

## 🔮 Possible Improvements

The project is still evolving. Possible future improvements include:

- Authentication and authorization
- User accounts and team management
- More comprehensive validation
- Automated unit and integration tests
- Improved error handling
- DTOs for API contracts
- More extensive database relationships
- CI/CD pipeline

## 👨‍💻 Author

**Kamil Wojtoł**

GitHub: [github.com/kamilwojtol](https://github.com/kamilwojtol)

LinkedIn: [linkedin.com/in/kamil-wojtol](https://www.linkedin.com/in/kamil-wojtol)
