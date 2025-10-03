using TrackingWorker.Models;

namespace TrackingWorker.Services.Interfaces;

/// <summary>
/// Dependency Inversion Principle: High-level modules depend on abstractions
/// Interface Segregation Principle: Specific interface for user operations
/// </summary>
public interface IUserService
{
    Task<UserResponseDto> CreateUserAsync(CreateUserDto userDto);
    Task<UserResponseDto?> GetUserByIdAsync(int id);
    Task<IEnumerable<UserResponseDto>> GetAllUsersAsync();
    Task<bool> DeleteUserAsync(int id);
}

/// <summary>
/// Interface Segregation Principle: Separate interface for validation
/// </summary>
public interface IUserValidator
{
    bool IsValidEmail(string email);
    bool IsValidName(string name);
}