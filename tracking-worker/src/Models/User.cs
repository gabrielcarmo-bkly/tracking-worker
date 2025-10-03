namespace TrackingWorker.Models;

/// <summary>
/// Single Responsibility Principle: This class only represents a User entity
/// </summary>
public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}

/// <summary>
/// Data Transfer Object for creating users
/// </summary>
public class CreateUserDto
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

/// <summary>
/// Data Transfer Object for user responses
/// </summary>
public class UserResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string CreatedAt { get; set; } = string.Empty;
}