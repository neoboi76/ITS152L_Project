# Teleoplex Inventory System

**Subtitle:** Streamlined inventory control for desktop-first teams

A lightweight, secure inventory management system with a Windows Forms desktop client and an ASP.NET Core Web API backend. Teleoplex Inventory System ("Teleoplex") is designed for small-to-medium organizations that prefer a responsive desktop UI while relying on a modern REST API for business logic, persistence, and auditability.

---

## 📋 Table of Contents

* [Overview](#-overview)
* [Features](#-features)
* [Tech Stack](#-tech-stack)
* [Prerequisites](#-prerequisites)
* [Local Setup (Manual)](#-local-setup-manual)

  * [Step 1: Clone the repository](#step-1-clone-the-repository)
  * [Step 2: Configure the database and appsettings](#step-2-configure-the-database-and-appsettings)
  * [Step 3: Apply EF Core migrations](#step-3-apply-ef-core-migrations)
  * [Step 4: Run the backend Web API](#step-4-run-the-backend-web-api)
  * [Step 5: Run the Windows Forms client](#step-5-run-the-windows-forms-client)
* [Project Structure](#-project-structure)
* [Testing the Application](#-testing-the-application)
* [Contributing & Notes](#-contributing--notes)
* [Team](#-team)
* [Repository](#-repository)
* [Acknowledgements](#-acknowledgements)

---

## 🎯 Overview

Teleoplex Inventory System provides a simple but extensible inventory management solution that separates the concerns of business logic (ASP.NET Core Web API) from the desktop user interface (Windows Forms). It includes core features such as item CRUD, user authentication, password reset via tokens, audit logging, a dashboard with key metrics, and CSV export functionality.

This project was created as a course / group project and is intentionally easy to run locally for development and testing.

---

## ✨ Features

* Item management (create, read, update, delete)
* User management and authentication (login, register, roles groundwork)
* Password reset token support
* Audit logging (actions recorded with timestamp, user, details)
* Dashboard with summary metrics (total value, low stock, top item)
* CSV export for audit logs and inventory lists
* Session/activity tracking in the WinForms client
* Password hashing and secure token utilities
* EF Core migrations included for schema management

---

## 🛠 Tech Stack

* **Backend:** ASP.NET Core Web API (C#)
* **Frontend / Client:** Windows Forms (.NET 9, net9.0-windows)
* **Data access:** Entity Framework Core (migrations included)
* **Security utilities:** BCrypt password hashing; secure token service
* **Project layout:** Solution with three projects: `ItemAPI`, `FormsUI`, and `ItemDataLibrary`

---

## 📦 Prerequisites

Make sure your machine meets the following requirements before proceeding:

* **OS:** Windows 10 / 11 (recommended for Windows Forms development)
* **.NET SDK:** .NET 9.0 SDK (matches `net9.0-windows` target framework)

  * Download: [https://dotnet.microsoft.com/](https://dotnet.microsoft.com/)
* **Visual Studio:** Visual Studio 2022/2023 with **.NET Desktop Development** workload (recommended) or Visual Studio Code with C# support
* **Database:** SQL Server (Express / LocalDB) or any SQL Server instance you prefer
* **Git:** for cloning the repository

> Note: The project expects a SQL-like connection string. The instructions below show a LocalDB example and a SQL Server example. Edit `ItemAPI/appsettings.json` accordingly.

---

## 🚀 Local Setup (Manual)

> These steps describe a local development setup (no Docker). Run the backend API first, then the Windows Forms client.

### Step 1: Clone the repository

```bash
# Clone the repository
git clone https://github.com/neoboi76/ITS152L_Project.git
cd ITS152L_Project
```

### Step 2: Configure the database and appsettings

1. Open `ITS152L-Project/ItemAPI/appsettings.json` and update the `ConnectionStrings` section to point to your database.

**Example — LocalDB (recommended for local dev):**

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=TeleoplexDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

**Example — SQL Server (replace with real values):**

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=TeleoplexDb;User Id=sa;Password=YourStrong!Passw0rd;MultipleActiveResultSets=true"
}
```

2. (Optional) Adjust other settings in `appsettings.json` such as the SMTP/email settings used by the password reset service.

3. Confirm the Web API's `launchSettings.json` port if you want to modify the base URL consumed by the WinForms client (the client expects `https://localhost:7173/` by default). You can update the base address in the WinForms code or change the API port to match.

### Step 3: Apply EF Core migrations

Open a command prompt or PowerShell at the `ITS152L-Project/ItemAPI` folder and run:

```powershell
# Install the EF tool if you don't have it (one time)
dotnet tool install --global dotnet-ef

# Restore and build
dotnet restore
dotnet build

# Apply migrations to create the database schema
dotnet ef database update
```

This will run the included migrations (see the `Migrations/` folder) and create the database schema indicated by the project.

### Step 4: Run the backend Web API

You can start the API from Visual Studio (set `ItemAPI` as the startup project) or use the CLI:

```bash
# from the solution root
dotnet run --project ITS152L-Project/ItemAPI/ItemApi.csproj
```

Confirm the API is running by visiting `https://localhost:7173` (or the port configured in `launchSettings.json`). Typical endpoints include `/api/item`, `/api/user`, `/api/login`, `/api/auditlog`, etc.

### Step 5: Run the Windows Forms client

1. Open the solution `ITS152L-Project/ItemAPI.sln` in Visual Studio.
2. Set `FormsUI` (or `FormUI`) as the startup project for the desktop client.
3. Ensure the backend API is running and reachable at the base URL configured in the Forms client (by default code uses `https://localhost:7173/`). If the API runs on a different port, update the `BaseAddress` in the Forms project HTTP client initialization or update `launchSettings.json`.
4. Run the WinForms project (F5).

The client will show the login screen. Create a user (or seed one using Db initialization if you added seed data) and start using the app.

---

## 🔧 Project Structure (high level)

```
ITS152L-Project/
├─ ItemAPI/            # ASP.NET Core Web API project (controllers, services, migrations)
├─ FormUI/             # Windows Forms desktop client (UI forms, session manager, activity tracker)
└─ ItemDataLibrary/    # Shared models, configuration and security helpers
```

Key folders in the API project:

* `Controllers/` — API endpoints (ItemController, UserController, LoginController, AuditLogController, PasswordResetController)
* `Data/` — DbContext and context factory
* `Repositories/` — Repository implementations and interfaces
* `Services/` — Business services (ItemService, UserService, SecureEmailService, AuditLogService)
* `Migrations/` — EF Core migrations

---

## ✅ Testing the Application

* Use the WinForms client to add, update, and delete items and observe the Audit Log via the client UI.
* Inspect API endpoints with tools like Postman or curl (e.g., `GET https://localhost:7173/api/item/getAll`).
* Export audit logs from the Audit Log form using the **Export to CSV** button for manual verification.

---

## 📝 Contributing & Notes

* The repository includes EF Core migrations; if you add or change models, create and add a migration (`dotnet ef migrations add <Name>`) then run `dotnet ef database update`.
* If you change the API port, update the FormsUI `HttpClient` `BaseAddress` to match.
* Roles/authorization scaffolding exists in the project but may require finishing (see TODOs in source files).

---

## 👥 Team

* Ken Aliling
* Carl Norbi Felonia
* Cedrick Miguel Kaneko
* Amar Jacob Pajarito
* Dino Alfred Timbol

---

## 🔗 Repository

`https://github.com/neoboi76/ITS152L_Project.git`  — Clone: `git clone https://github.com/neoboi76/ITS152L_Project.git`

---

## 🙏 Acknowledgements

This project was developed as part of an academic group project. Thanks to the contributors listed above and to the maintainers of .NET, EF Core, and Windows Forms libraries that made prototyping this app straightforward.

---

**License**: (optional) Add a license file (e.g., `LICENSE` with MIT) if you want others to reuse the code.
