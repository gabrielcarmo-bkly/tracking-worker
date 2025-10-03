using TrackingWorker.Services.Interfaces;

namespace TrackingWorker.Common.Validators;

/// <summary>
/// Single Responsibility Principle: Only handles user validation logic
/// Interface Segregation Principle: Implements specific validation interface
/// </summary>
public class UserValidator : IUserValidator
{
    public bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            // Simple email validation
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    public bool IsValidName(string name)
    {
        return !string.IsNullOrWhiteSpace(name) && name.Length >= 2 && name.Length <= 100;
    }
}