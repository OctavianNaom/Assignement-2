using Microsoft.Extensions.Logging;

namespace CLI.UI.ManageUsers;
using RepositoryContracts;
using InMemoryRepositories;
using Entities;

public class CreateUserView
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<CreateUserView> _logger;

    public CreateUserView(IUserRepository userRepository, ILogger<CreateUserView> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    public async Task CreateUserAsync()
    {
        Console.WriteLine("Creating a new user");
        Console.Write("Username: ");
        var username = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(username))
        {
            Console.WriteLine("Username cannot be empty.");
            _logger.LogWarning("Attempted to create a user with an empty username.");
            return;
        }
        Console.Write("Password: ");
        var password = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("Password cannot be empty.");
            _logger.LogWarning("Attempted to create a user with an empty password.");
            return;
        }
        var newUser = new User
        {
            Username = username,
            PasswordHash = password 
        };
        try
        {
            await _userRepository.AddAsync(newUser);
            Console.WriteLine($"User '{username}' created successfully.");
            _logger.LogInformation($"User '{username}' created successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while creating the user.");
            _logger.LogError(ex, $"Error while creating user '{username}': {ex.Message}");
        }
    }
}