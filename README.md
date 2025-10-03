# TrackingWorker - SOLID Architecture Learning Project

A comprehensive C# console application built with .NET 8 that demonstrates all 5 SOLID principles through a User Management System.

## 🎯 What You'll Learn

- **SOLID Principles** in action with real code examples
- **Dependency Injection** and IoC containers
- **Layered Architecture** with clean separation of concerns
- **C# Best Practices** and professional coding patterns

## 🏗️ Architecture Overview

```
┌─────────────────┐    ┌─────────────────┐    ┌─────────────────┐
│   Controllers   │───▶│    Services     │───▶│  Repositories   │
│ (Coordination)  │    │ (Business Logic)│    │  (Data Access)  │
└─────────────────┘    └─────────────────┘    └─────────────────┘
         │                       │                       │
         ▼                       ▼                       ▼
┌─────────────────┐    ┌─────────────────┐    ┌─────────────────┐
│     Models      │    │   Validators    │    │   Configuration │
│ (Data Entities) │    │ (Business Rules)│    │ (DI Container)  │
└─────────────────┘    └─────────────────┘    └─────────────────┘
```

## 📁 Professional Project Structure

```
TrackingWorker/                     # 🏠 Project root
├── src/                           # 📦 Source code
│   ├── Models/                    # 📊 Data entities and DTOs
│   ├── Services/                  # 🧠 Business logic layer
│   │   ├── Interfaces/           # 📋 Service contracts
│   │   └── Implementations/      # ⚙️ Business logic
│   ├── Repositories/             # 💾 Data access layer
│   │   ├── Interfaces/           # 📋 Data contracts  
│   │   └── Implementations/      # 🗄️ Data persistence
│   ├── Controllers/              # 🎮 Request coordination
│   ├── Common/                   # 🔧 Shared components
│   │   ├── Validators/           # ✅ Validation logic
│   │   └── Exceptions/           # ⚠️ Custom exceptions
│   ├── Configuration/            # ⚙️ Dependency injection
│   └── Program.cs               # 🚀 Application entry point
├── tests/                        # 🧪 Unit and integration tests
├── .vscode/                      # ⚙️ VS Code configuration
├── .github/                      # 🐙 GitHub configuration
├── TrackingWorker.csproj        # 📦 Project file
├── .gitignore                   # 🙈 Git ignore rules
└── README.md                    # 📖 This file
```

## 🚀 Getting Started

### Prerequisites

- .NET 8 SDK (already installed in this workspace)

### Build and Run

```bash
# Build the project
dotnet build TrackingWorker.csproj

# Run the application
dotnet run --project TrackingWorker.csproj
```

### Interactive Demo

The application provides a menu-driven interface to:
- ✅ Create new users with validation
- 📋 View all users
- 🔍 Search users by ID
- ❌ Delete users

## 📁 Project Structure

```
MyFirstCSharpApp/
├── Models/                    # 📦 Data entities and DTOs
├── Services/                  # 🧠 Business logic layer
│   ├── Interfaces/           # 📋 Service contracts
│   └── Implementations/      # ⚙️ Business logic
├── Repositories/             # 💾 Data access layer
│   ├── Interfaces/           # 📋 Data contracts  
│   └── Implementations/      # 🗄️ Data persistence
├── Controllers/              # 🎮 Request coordination
├── Common/                   # 🔧 Shared components
│   ├── Validators/           # ✅ Validation logic
│   └── Exceptions/           # ⚠️ Custom exceptions
├── Configuration/            # ⚙️ Dependency injection
├── Program.cs               # 🚀 Application entry point
├── SOLID_GUIDE.md           # 📚 Detailed SOLID explanation
└── README.md               # 📖 This file
```

## 🎓 SOLID Principles Demonstrated

| Principle | Implementation | Example |
|-----------|----------------|---------|
| **SRP** | Each class has one responsibility | `UserValidator` only validates |
| **OCP** | Open for extension, closed for modification | Add new repository without changing service |
| **LSP** | Substitutable implementations | Swap `InMemoryRepository` with `DatabaseRepository` |
| **ISP** | Small, focused interfaces | `IUserService`, `IUserRepository` separate |
| **DIP** | Depend on abstractions | `UserService` uses `IUserRepository` interface |

## 🧪 Try It Yourself

1. **Run the app** and create some users
2. **Read SOLID_GUIDE.md** for detailed explanations
3. **Modify the code** to see principles in action:
   - Add new validation rules
   - Create a database repository
   - Add new services

## 🔧 Dependencies

- **Microsoft.Extensions.DependencyInjection** - IoC container for dependency injection
- **.NET 8.0** - Latest .NET runtime with modern C# features

## 📚 Learning Path

1. **Start here**: Run the application and explore the menu
2. **Understand structure**: Explore the `src/` folder and each layer
3. **Learn SOLID**: Study the code comments explaining each principle
4. **Experiment**: Try modifying code to see patterns in action
5. **Test**: Create unit tests in the `tests/` directory
6. **Extend**: Add new features following the same patterns

## 🎓 Key Learning Points

- **Clean Code** principles with focused classes
- **SOLID principles** implemented throughout the codebase
- **Dependency Injection** for loose coupling
- **Layered Architecture** for separation of concerns
- **Professional project structure** used in enterprise applications

This project provides a solid foundation for learning professional C# development! 🎯