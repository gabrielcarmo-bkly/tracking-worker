using TrackingWorker.Models;
using TrackingWorker.Repositories.Interfaces;

namespace TrackingWorker.Repositories.Implementations;

/// <summary>
/// Single Responsibility Principle: Only handles user data persistence
/// Open/Closed Principle: Can be extended without modification
/// Liskov Substitution Principle: Can be substituted for any IUserRepository
/// </summary>
public class InMemoryUserRepository : IUserRepository
{
    private readonly List<User> _users = new();
    private int _nextId = 1;

    public Task<User> CreateAsync(User user)
    {
        user.Id = _nextId++;
        _users.Add(user);
        return Task.FromResult(user);
    }

    public Task<User?> GetByIdAsync(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        return Task.FromResult(user);
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<User>>(_users.ToList());
    }

    public Task<bool> DeleteAsync(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null) return Task.FromResult(false);
        
        _users.Remove(user);
        return Task.FromResult(true);
    }

    public Task<User?> GetByEmailAsync(string email)
    {
        var user = _users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(user);
    }
}