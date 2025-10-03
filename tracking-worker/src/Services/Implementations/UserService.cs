using TrackingWorker.Models;
using TrackingWorker.Services.Interfaces;
using TrackingWorker.Repositories.Interfaces;

namespace TrackingWorker.Services.Implementations;

/// <summary>
/// Single Responsibility Principle: Only handles user business logic
/// Open/Closed Principle: Open for extension, closed for modification
/// Dependency Inversion Principle: Depends on abstractions, not concretions
/// </summary>
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserValidator _userValidator;

    public UserService(IUserRepository userRepository, IUserValidator userValidator)
    {
        _userRepository = userRepository;
        _userValidator = userValidator;
    }

    public async Task<UserResponseDto> CreateUserAsync(CreateUserDto userDto)
    {
        // Validation
        if (!_userValidator.IsValidEmail(userDto.Email))
            throw new ArgumentException("Invalid email format");

        if (!_userValidator.IsValidName(userDto.Name))
            throw new ArgumentException("Invalid name");

        // Business logic
        var user = new User
        {
            Name = userDto.Name,
            Email = userDto.Email,
            CreatedAt = DateTime.UtcNow
        };

        var savedUser = await _userRepository.CreateAsync(user);

        return new UserResponseDto
        {
            Id = savedUser.Id,
            Name = savedUser.Name,
            Email = savedUser.Email,
            CreatedAt = savedUser.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")
        };
    }

    public async Task<UserResponseDto?> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) return null;

        return new UserResponseDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            CreatedAt = user.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")
        };
    }

    public async Task<IEnumerable<UserResponseDto>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return users.Select(user => new UserResponseDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            CreatedAt = user.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")
        });
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        return await _userRepository.DeleteAsync(id);
    }
}