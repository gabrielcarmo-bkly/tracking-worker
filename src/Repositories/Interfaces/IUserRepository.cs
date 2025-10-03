using TrackingWorker.Models;

namespace TrackingWorker.Repositories.Interfaces;

/// <summary>
/// Interface Segregation Principle: Specific interface for data access
/// Dependency Inversion Principle: Abstraction for data layer
/// </summary>
public interface IUserRepository
{
    Task<User> CreateAsync(User user);
    Task<User?> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAllAsync();
    Task<bool> DeleteAsync(int id);
    Task<User?> GetByEmailAsync(string email);
}