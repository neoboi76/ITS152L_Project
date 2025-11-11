# Teleoplex Inventory System

[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4.svg)](https://dotnet.microsoft.com/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-9.0-512BD4.svg)](https://dotnet.microsoft.com/apps/aspnet)
[![Windows Forms](https://img.shields.io/badge/Windows%20Forms-9.0-0078D6.svg)](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-2019+-CC2927.svg)](https://www.microsoft.com/sql-server)

**Bringing the future into the present, for itself, by itself**

A modern inventory management solution built with ASP.NET Core Web API and Windows Forms, featuring comprehensive user authentication, role-based access control, audit logging, and real-time inventory tracking capabilities.

---

## 📋 Table of Contents

- [Overview](#-overview)
- [Features](#-features)
- [Tech Stack](#-tech-stack)
- [Prerequisites](#-prerequisites)
- [Local Setup](#-local-setup)
  - [Step 1: Clone the Repository](#step-1-clone-the-repository)
  - [Step 2: Database Setup](#step-2-database-setup)
  - [Step 3: Backend API Setup](#step-3-backend-api-setup)
  - [Step 4: Frontend Application Setup](#step-4-frontend-application-setup)
- [Testing the Application](#-testing-the-application)
- [Project Documentation](#-project-documentation)
- [Team](#-team)
- [Acknowledgements](#-acknowledgements)

---

## 🎯 Overview

Teleoplex Inventory System is an enterprise-grade inventory management platform designed to streamline item tracking, user management, and audit operations. The system provides a seamless experience for managing inventory items with comprehensive CRUD operations, while giving administrators powerful tools to manage users, track changes through audit logs, and maintain system security.

**Key Capabilities:**

- Comprehensive item management with detailed tracking
- Multi-layered user authentication with JWT security
- Role-based access control (Admin and User roles)
- Complete audit trail logging for compliance
- Session management with automatic timeout
- Password reset functionality via secure email verification
- Real-time inventory updates and synchronization
- Export capabilities to CSV format
- Professional reporting with print-to-PDF functionality

---

## ✨ Features

- ✅ **User Authentication**: Secure registration, login, and password management with BCrypt hashing
- ✅ **Role-Based Access Control**: Separate views and permissions for Admin and User roles
- ✅ **Inventory Management**: Full CRUD operations for inventory items with real-time updates
- ✅ **Audit Logging**: Comprehensive activity tracking with timestamp, user, and action details
- ✅ **Admin Dashboard**: Visual statistics and recent activity monitoring
- ✅ **User Management**: Admin interface for user administration and role assignment
- ✅ **Password Reset**: Secure token-based password recovery with email verification
- ✅ **Session Management**: Automatic timeout after 10 minutes of inactivity
- ✅ **Search & Filter**: Advanced search and multi-criteria sorting capabilities
- ✅ **Export Functionality**: CSV export and PDF reporting capabilities
- ✅ **Modern UI**: Professional interface with Segoe UI design language

---

## 🛠 Tech Stack

### Backend

- **ASP.NET Core 9.0** (Web API)
- **Entity Framework Core 9.0** (ORM)
- **SQL Server 2019+** (Database)
- **BCrypt.Net** (Password Hashing)
- **System.Net.Mail** (Email Integration)
- **JWT Authentication** (Token-based Security)

### Frontend

- **Windows Forms (.NET 9.0)**
- **System.Drawing** (UI Components)
- **HttpClient** (API Communication)
- **DataGridView** (Data Presentation)

### Architecture

- **Repository Pattern** (Data Access Layer)
- **Service Layer** (Business Logic)
- **Dependency Injection** (IoC Container)
- **RESTful API** (HTTP Communication)

---

## 📦 Prerequisites

Before you begin, ensure you have the following installed:

### Required Software

| Software | Version | Download Link |
|----------|---------|---------------|
| **Visual Studio 2022** | Community/Professional | [Download](https://visualstudio.microsoft.com/downloads/) |
| **.NET SDK** | 9.0+ | [Download](https://dotnet.microsoft.com/download) |
| **SQL Server** | 2019+ | [Download](https://www.microsoft.com/sql-server/sql-server-downloads) |
| **SSMS** | Latest | [Download](https://docs.microsoft.com/sql/ssms/download-sql-server-management-studio-ssms) |
| **Git** | Latest | [Download](https://git-scm.com/) |

### Configuration Requirements

**Gmail App Password** (for password reset functionality):
- Visit: https://myaccount.google.com/apppasswords
- Generate an app-specific password
- Use this instead of your regular Gmail password

---

## 🚀 Local Setup

### Step 1: Clone the Repository

```bash
# Clone the repository
git clone https://github.com/neoboi76/ITS152L_Project.git

# Navigate to project directory
cd ITS152L_Project
```

---

### Step 2: Database Setup

#### Option A: Using SQL Server Management Studio (SSMS)

1. **Open SSMS and connect to your SQL Server instance**

2. **Create a new database:**
   ```sql
   CREATE DATABASE TeleoplexInventoryDB;
   GO
   ```

3. **Verify connection:**
   - Server name: `localhost` or `.\SQLEXPRESS`
   - Database: `TeleoplexInventoryDB`
   - Authentication: Windows Authentication (recommended)

#### Option B: Using Visual Studio Server Explorer

1. Open Visual Studio
2. View → Server Explorer
3. Right-click "Data Connections" → Add Connection
4. Server name: `localhost` or `.\SQLEXPRESS`
5. Create new database: `TeleoplexInventoryDB`

---

### Step 3: Backend API Setup

#### 1. Open Solution in Visual Studio

```bash
# Navigate to the solution
cd ITS152L-Project

# Open the solution file
start ItemAPI.sln
```

Or open Visual Studio → File → Open → Project/Solution → Select `ItemAPI.sln`

#### 2. Configure Connection String

The project uses User Secrets for secure configuration. Set up your connection string:

1. Right-click on the `ItemApi` project → Manage User Secrets
2. Add the following JSON configuration:

```json
{
  "ConnectionStrings": {
    "SqlDb": "Server=localhost;Database=TeleoplexInventoryDB;Trusted_Connection=True;TrustServerCertificate=True"
  },
  "EmailSettings": {
    "SenderEmail": "your-email@gmail.com",
    "AppPassword": "your-gmail-app-password",
    "SmtpServer": "smtp.gmail.com",
    "SmtpPort": 587,
    "EnableSsl": true
  }
}
```

**Important Notes:**
- Replace `your-email@gmail.com` with your Gmail address
- Replace `your-gmail-app-password` with your Gmail app-specific password
- Adjust the `Server` value if using a named instance (e.g., `.\SQLEXPRESS`)

#### 3. Apply Database Migrations

The application uses Entity Framework Core Code-First approach:

**Option A: Using Package Manager Console**

1. Tools → NuGet Package Manager → Package Manager Console
2. Ensure `ItemApi` is selected as the Default Project
3. Run:
   ```powershell
   Update-Database
   ```

**Option B: Using .NET CLI**

```bash
cd ItemAPI
dotnet ef database update
```

This will create all necessary tables:
- Users
- Items
- AuditLogs
- PasswordResetTokens

#### 4. Run the Backend API

**Method 1: Using Visual Studio**

1. Set `ItemApi` as the startup project (right-click → Set as Startup Project)
2. Press `F5` or click the green "play" button
3. The API will start on `https://localhost:7173`

**Method 2: Using Command Line**

```bash
cd ItemAPI
dotnet run
```

#### 5. Verify Backend is Running

The API should be accessible at:
- HTTPS: `https://localhost:7173`
- HTTP: `http://localhost:5111`

You can test by visiting `https://localhost:7173/api/item/getAll` (will show 401 Unauthorized, which is expected).

---

### Step 4: Frontend Application Setup

#### 1. Open the Windows Forms Project

In Visual Studio:
1. Right-click on the `FormsUI` project → Set as Startup Project
2. Verify the project references are correctly loaded

#### 2. Build the Solution

```bash
# From the solution root
dotnet build
```

Or in Visual Studio: Build → Build Solution (Ctrl+Shift+B)

#### 3. Configure API Base Address

The frontend is pre-configured to connect to `https://localhost:7173/`. If your API runs on a different port:

1. Open `FormUI/InventoryForm.cs`
2. Locate the HttpClient initialization:
   ```csharp
   private readonly HttpClient _httpClient = new HttpClient
   {
       BaseAddress = new Uri("https://localhost:7173/")
   };
   ```
3. Update the port if necessary

#### 4. Run the Frontend Application

**Make sure the Backend API is running first!**

**Method 1: Using Visual Studio**

1. Ensure `FormsUI` is set as the startup project
2. Press `F5` or click the green "play" button
3. The application will launch showing the Login form

**Method 2: Using Command Line**

```bash
cd FormUI
dotnet run
```

#### 5. Application Launch

The Windows Forms application will start with the Login screen. You can now:
- Register a new account
- Log in with existing credentials
- Use password reset if needed

---

## 🧪 Testing the Application

### Initial Setup

When you first run the application, the database will be empty. You'll need to:

1. **Register a New Account**
   - Click "Create new account" on the Login form
   - Fill in required information:
     - Email address (must be valid format)
     - First Name
     - Last Name
     - Password (minimum 8 characters, must include uppercase, lowercase, and numbers)
     - Confirm Password
   - Click "Sign Up"

2. **First User is Admin**
   - The system automatically assigns Admin role to the first registered user
   - Subsequent users will have User role by default
   - Admins can promote users through the User Management interface

### User Features (All Roles)

1. **View Inventory**
   - Browse all inventory items in the main grid
   - Use search functionality to find specific items
   - Sort by various criteria (Name, Code, Brand, Price, Quantity)

2. **Session Management**
   - System tracks user activity
   - Automatic logout after 10 minutes of inactivity
   - Activity includes mouse movements, clicks, and keyboard input

3. **Password Reset**
   - Click "Forgot password?" on Login form
   - Enter registered email address
   - Receive 6-digit verification code via email
   - Code expires after 10 minutes
   - Enter code and set new password

### Admin Features

1. **Inventory Management**
   - Add new items with details (Name, Code, Brand, Price, Quantity)
   - Edit existing items
   - Delete items (with confirmation)
   - All changes are logged in audit trail

2. **Dashboard Access**
   - View → Dashboard
   - See statistics:
     - Total Items count
     - Total Inventory Value
     - Low Stock Items (quantity < 10)
     - Top Item by quantity
   - View recent activity feed

3. **Audit Log**
   - View → Audit Log
   - Filter by date range
   - Filter by action type (Added, Updated, Deleted)
   - Export audit logs to CSV
   - Track all system changes with user attribution

4. **User Management**
   - View → User Management
   - View all registered users
   - Toggle user roles (User ↔ Admin)
   - Delete user accounts
   - Search and filter users

5. **Export Capabilities**
   - Print → Print Inventory List
   - Print → Print Preview
   - Print → Save as PDF
   - File → Export to CSV

### Testing Scenarios

**Scenario 1: Basic Inventory Operations**
```
1. Login as Admin
2. Click "New Item"
3. Enter item details:
   - Name: "Laptop"
   - Code: 12345
   - Brand: "Dell"
   - Price: 45000
   - Quantity: 10
4. Click "Save"
5. Verify item appears in grid
6. Select item and click "Update"
7. Change Quantity to 8
8. Click "Save"
9. View → Audit Log to see changes
```

**Scenario 2: User Role Management**
```
1. Login as Admin
2. View → User Management
3. Select a user
4. Click "Toggle Admin"
5. Confirm role change
6. Verify user role updated in grid
7. Check Audit Log for user role change
```

**Scenario 3: Session Timeout**
```
1. Login to the system
2. Leave application idle for 10 minutes
3. System will automatically log you out
4. Message will prompt: "Your session has expired due to inactivity"
5. Redirected to Login screen
```

**Scenario 4: Password Reset**
```
1. On Login screen, click "Forgot password?"
2. Enter your registered email
3. Click "Send Code"
4. Check your email for 6-digit code
5. Enter code in verification field
6. Click "Verify Code"
7. Enter new password (meeting requirements)
8. Confirm new password
9. Click "Reset Password"
10. Login with new credentials
```

---

## 📖 Project Documentation

### Architecture Overview

The Teleoplex Inventory System follows a multi-tier architecture:

```
┌─────────────────────────────────────┐
│     Presentation Layer (WinForms)   │
│   - LoginForm, InventoryForm, etc.  │
│   - SessionManager, ActivityTracker │
└──────────────┬──────────────────────┘
               │ HTTP/HTTPS
               ▼
┌─────────────────────────────────────┐
│      API Layer (Controllers)        │
│   - ItemController                  │
│   - UserController                  │
│   - AuditLogController              │
└──────────────┬──────────────────────┘
               │
               ▼
┌─────────────────────────────────────┐
│     Service Layer (Business Logic)  │
│   - ItemService                     │
│   - UserService                     │
│   - AuditLogService                 │
└──────────────┬──────────────────────┘
               │
               ▼
┌─────────────────────────────────────┐
│  Repository Layer (Data Access)     │
│   - GenericRepository<T>            │
│   - ItemRepository                  │
│   - UserRepository                  │
└──────────────┬──────────────────────┘
               │
               ▼
┌─────────────────────────────────────┐
│     Data Layer (Entity Framework)   │
│   - ItemApiContext                  │
│   - Models: Item, User, AuditLog    │
└─────────────────────────────────────┘
```

### Key Components

**Backend (ItemAPI)**
- `Controllers/` - HTTP endpoint handlers
- `Services/` - Business logic implementation
- `Repositories/` - Data access abstraction
- `Data/` - EF Core context and migrations
- `Models/` - Entity definitions

**Frontend (FormsUI)**
- `LoginForm.cs` - User authentication
- `InventoryForm.cs` - Main inventory interface
- `DashboardForm.cs` - Statistics and overview
- `AuditLogForm.cs` - Activity tracking
- `UserManagementForm.cs` - User administration
- `SessionManager.cs` - Session and timeout handling

**Shared (ItemDataLibrary)**
- `Models/` - Data transfer objects
- `Security/` - Password hashing utilities
- `Configuration/` - Email settings

### Security Features

1. **Password Security**
   - BCrypt hashing with salt rounds
   - Minimum password requirements enforced
   - Secure password reset with time-limited tokens

2. **Authentication**
   - JWT token-based authentication ready
   - Session management with activity tracking
   - Automatic timeout after inactivity

3. **Authorization**
   - Role-based access control (RBAC)
   - Admin-only endpoints protected
   - User-specific data isolation

4. **Audit Trail**
   - All CRUD operations logged
   - User attribution for all actions
   - Timestamp tracking for compliance

### Database Schema

**Users Table**
- Id (int, PK, Identity)
- UserName (nvarchar, Unique)
- FirstName (nvarchar)
- LastName (nvarchar)
- Password (nvarchar, hashed)
- Role (nvarchar)

**Items Table**
- Id (int, PK, Identity)
- Name (nvarchar)
- Code (int)
- Brand (nvarchar)
- UnitPrice (float)
- Quantity (int)

**AuditLogs Table**
- Id (int, PK, Identity)
- UserName (nvarchar)
- Action (nvarchar)
- EntityType (nvarchar)
- EntityId (int)
- Details (nvarchar)
- Timestamp (datetime2)

**PasswordResetTokens Table**
- Id (int, PK, Identity)
- Token (nvarchar(6))
- UserId (int, FK)
- Expiry (datetime2)
- IsUsed (bit)
- CreatedAt (datetime2)
- UsedAt (datetime2, nullable)

---

## 👥 Team

**Group 9 - ITS152L Project**

| Name | Role | Contributions |
|------|------|---------------|
| **Ken Aliling** | Developer | Backend services, API development, Business logic implementation |
| **Carl Norbi Felonia** | Developer | Frontend components, Windows Forms UI, User interface design |
| **Cedrick Miguel Kaneko** | Developer | Database design, Entity Framework, Data migrations |
| **Amar Jacob Pajarito** | Developer | Security implementation, Authentication, Password management |
| **Dino Alfred Timbol** | Lead Developer | System architecture, Integration, Project coordination |

**Course:** ITS152L - Advanced Systems Integration and Architecture 2  
**Institution:** _Mapúa University - School of Information Technology_  
**Academic Year:** 2024-2025

---

## 🙏 Acknowledgements

We would like to express our gratitude to:

- **Prof. Antonette Gabriel** - For guidance and support throughout the project development
- **Mapúa University** - For providing the resources and environment for learning
- **Microsoft Documentation Team** - For comprehensive .NET documentation
- **Stack Overflow Community** - For invaluable troubleshooting assistance

### Technologies & Frameworks

Special thanks to the open-source projects and technologies that made this possible:

- [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet)
- [Entity Framework Core](https://docs.microsoft.com/ef/core/)
- [BCrypt.Net](https://github.com/BcryptNet/bcrypt.net)
- [SQL Server](https://www.microsoft.com/sql-server)
- [.NET Foundation](https://dotnetfoundation.org/)

---

## 📞 Contact

For questions, suggestions, or collaboration opportunities:

- **GitHub Repository:** [ITS152L_Project](https://github.com/neoboi76/ITS152L_Project)
- **GitHub Issues:** [Create an issue](https://github.com/neoboi76/ITS152L_Project/issues)

---

<dl>
  <dt><strong>Te·le·o·plexy</strong></dt>
  <dd>
    <em>(noun) — (self-reinforcing) cybernetic intensification;</em><br>
    describes the wave-length of machines, escaping in the direction of extreme ultra-violet among the cosmic rays.
  </dd>
  <dd>
    <strong>Also known as:</strong> self-reinforcing cybernetic intensification
  </dd>
  <dd><small>Made by Group 9</small></dd>
</dl>

