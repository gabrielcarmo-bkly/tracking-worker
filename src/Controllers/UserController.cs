using TrackingWorker.Models;
using TrackingWorker.Services.Interfaces;

namespace TrackingWorker.Controllers;

/// <summary>
/// Single Responsibility Principle: Only handles user-related requests/coordination
/// Dependency Inversion Principle: Depends on service abstraction
/// </summary>
public class UserController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    public async Task HandleCreateUserAsync()
    {
        try
        {
            Console.WriteLine("=== Create User ===");
            Console.Write("Enter name: ");
            var name = Console.ReadLine() ?? string.Empty;
            
            Console.Write("Enter email: ");
            var email = Console.ReadLine() ?? string.Empty;

            var createUserDto = new CreateUserDto { Name = name, Email = email };
            var result = await _userService.CreateUserAsync(createUserDto);
            
            Console.WriteLine($"✅ User created successfully!");
            Console.WriteLine($"ID: {result.Id}, Name: {result.Name}, Email: {result.Email}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error: {ex.Message}");
        }
    }

    public async Task HandleGetAllUsersAsync()
    {
        try
        {
            Console.WriteLine("=== All Users ===");
            var users = await _userService.GetAllUsersAsync();
            
            if (!users.Any())
            {
                Console.WriteLine("No users found.");
                return;
            }

            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id} | Name: {user.Name} | Email: {user.Email} | Created: {user.CreatedAt}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error: {ex.Message}");
        }
    }

    public async Task HandleGetUserByIdAsync()
    {
        try
        {
            Console.WriteLine("=== Get User by ID ===");
            Console.Write("Enter user ID: ");
            
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("❌ Invalid ID format");
                return;
            }

            var user = await _userService.GetUserByIdAsync(id);
            
            if (user == null)
            {
                Console.WriteLine("❌ User not found");
                return;
            }

            Console.WriteLine($"✅ User found:");
            Console.WriteLine($"ID: {user.Id} | Name: {user.Name} | Email: {user.Email} | Created: {user.CreatedAt}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error: {ex.Message}");
        }
    }
}