// Initial TrackingWorker Console Applicationusing Microsoft.Extensions.DependencyInjection;

// Built with .NET 8using MyFirstCSharpApp.Configuration;

using MyFirstCSharpApp.Controllers;

Console.WriteLine("🏗️ TrackingWorker - Initial Setup");

Console.WriteLine("Welcome to the TrackingWorker console application!");/// <summary>
/// Main entry point demonstrating SOLID principles:
/// - Dependency Inversion: Using DI container instead of direct instantiation
/// - Single Responsibility: Main only handles application bootstrapping
/// </summary>

// Configure Dependency Injection Container
var services = new ServiceCollection();
services.ConfigureServices();

// Build the service provider
using var serviceProvider = services.BuildServiceProvider();

// Resolve dependencies (Dependency Inversion Principle)
var userController = new UserController(serviceProvider.GetRequiredService<MyFirstCSharpApp.Services.Interfaces.IUserService>());

Console.WriteLine("🏗️  SOLID Architecture Demo - User Management System");
Console.WriteLine("====================================================");

bool running = true;
while (running)
{
    Console.WriteLine("\nChoose an option:");
    Console.WriteLine("1. Create User");
    Console.WriteLine("2. View All Users");
    Console.WriteLine("3. Get User by ID");
    Console.WriteLine("4. Exit");
    Console.Write("\nEnter your choice (1-4): ");

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            await userController.HandleCreateUserAsync();
            break;
        case "2":
            await userController.HandleGetAllUsersAsync();
            break;
        case "3":
            await userController.HandleGetUserByIdAsync();
            break;
        case "4":
            running = false;
            Console.WriteLine("👋 Goodbye!");
            break;
        default:
            Console.WriteLine("❌ Invalid choice. Please try again.");
            break;
    }
}

/* 
🎯 SOLID Principles Demonstrated:

1. Single Responsibility Principle (SRP):
   - User: Only represents user data
   - UserService: Only handles user business logic
   - UserRepository: Only handles data persistence
   - UserValidator: Only handles validation logic

2. Open/Closed Principle (OCP):
   - Services are open for extension but closed for modification
   - You can add new implementations without changing existing code

3. Liskov Substitution Principle (LSP):
   - InMemoryUserRepository can be replaced with DatabaseUserRepository
   - Any IUserService implementation can replace UserService

4. Interface Segregation Principle (ISP):
   - Separate interfaces: IUserService, IUserRepository, IUserValidator
   - Clients only depend on interfaces they use

5. Dependency Inversion Principle (DIP):
   - High-level modules (UserService) depend on abstractions (IUserRepository)
   - Details (InMemoryUserRepository) depend on abstractions
   - Dependencies are injected, not created directly
*/
