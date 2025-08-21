📋 Task Management System

A Task Management System built with Blazor Server (frontend) and ASP.NET Core Web API (.NET 8) (backend).
This project demonstrates a modern full-stack .NET application with CRUD functionality, clean architecture, and Bootstrap UI.

🚀 Features

✅ Create, Read, Update, and Delete (CRUD) tasks

✅ View tasks in table view and card view

✅ Task status management with Bootstrap badges (Pending, In Progress, Completed, Overdue)

✅ Toast notifications for success/error messages

✅ Loading spinners during API calls

✅ Modular Blazor components:

TaskCard – alternative card view for tasks

Alert – dismissible alert messages

Toast – auto-dismiss notifications

LoadingOverlay – global spinner overlay

✅ RESTful API built with ASP.NET Core Web API (.NET 8)

✅ EF Core integration for database persistence (InMemory/ Seed data thru Program.cs)

🏗️ Project Structure
TaskManagementSystem/
│
├── TaskBlazor.Database/         # Class Library (.NET 8)
│   ├── TaskDbContext/             # Task DbContext for EF
|
├── TaskBlazor.Domain/         # Class Library for Model and Entity (.NET 8)
│   ├── Enums/             # Enums
│   └── Task.cs               # Entity
|
├── TaskBlazor.TaskApplication/         # Class Library for Business layer (.NET 8)
│   ├── Interface/             # Interface layer
│   └── TaskService.cs               # business logic
|
├── TaskBlazor.TaskWebApi/         # ASP.NET Core Web API (.NET 8)
│   ├── Controllers/             # Task API controllers
│   └── Program.cs               # API bootstrap
│
├── TaskBlazor.TaskBlazor/      # Blazor Server frontend
│   ├── Shared/                 # Reusable Layout (MainLayout, NavMenu, etc.)
|   |   ├── Components/         # Reusable components (TaskCard, Toast, etc.)
│   ├── Pages/                   # Razor pages (Index, Cards, etc.)
│   ├── Services/                # API service clients
│   └── Program.cs               # Blazor app bootstrap
│
└── README.md                   # Project documentation

⚙️ Tech Stack

Frontend: Blazor Server, Bootstrap 5

Backend: ASP.NET Core Web API (.NET 8)

Database: EF Core with SQL Server (or SQLite for local dev)

Tools: C#, LINQ, Dependency Injection

🔧 Getting Started
1️⃣ Clone the Repository
git clone https://github.com/akosiar2/TaskManagementBlazor.git
cd TaskManagementSystem

2️⃣ Run the API
cd TaskManagement.Api
dotnet run


The API will start at:
👉 https://localhost:7280 (HTTPS)
👉 http://localhost:5187 (HTTP)

3️⃣ Run the Blazor Server App

Open a new terminal:

cd TaskManagement.Blazor
dotnet run


The Blazor app will start at:
👉 https://localhost:7001

📌 API Endpoints
Method	Endpoint	Description
GET	/api/tasks	Get all tasks
GET	/api/tasks/{id}	Get task by ID
POST	/api/tasks	Create new task
PUT	/api/tasks/{id}	Update task
DELETE	/api/tasks/{id}	Delete task
📸 Screenshots (Optional)

Add screenshots here for table view, card view, and toast notifications.

🛠️ Future Enhancements

🔹 Authentication & Authorization (ASP.NET Identity + JWT)

🔹 User-specific task management

🔹 Task categories & priority levels

🔹 SignalR for real-time updates

👨‍💻 Author

Developed by Arvin Roman Agramon
📧 Contact: aragramon@gmail.com
]
