using RepositoryContracts;
using Entities;
using InMemoryRepositories;
namespace CLI.UI.ManageUsers;

public class ManageUsersView
{
    private readonly IUserRepository _userRepository;

    public ManageUsersView(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task DisplayAsync()
    {
        while (true)
        {
            Console.WriteLine("User Management Menu:");
            Console.WriteLine("1. List all users");
            Console.WriteLine("2. Create a new user");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");
            
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await ListUsersAsync();
                    break;
                case "2":
                    await CreateUserAsync();
                    break;
                case "3":
                    Console.WriteLine("Exiting User Management.");
                    return; 
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private async Task ListUsersAsync()
    {
        Console.WriteLine("Listing all users...");

        try
        {
            var users = _userRepository.GetMany();

            if (users == null || !users.GetType().IsSubclassOf(typeof(User)))
            {
                Console.WriteLine("No users found.");
                return;
            }

            Console.WriteLine("Users:");
            foreach (var user in users)
            {
                Console.WriteLine($"- Username: {user.Username}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while listing users: {ex.Message}");
        }
    }

    private async Task CreateUserAsync()
    {
        Console.WriteLine("Creating a new user...");

        Console.Write("Enter username: ");
        var username = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(username))
        {
            Console.WriteLine("Username cannot be empty.");
            return;
        }

        Console.Write("Enter password: ");
        var password = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("Password cannot be empty.");
            return;
        }

        var newUser = new User
        {
            Username = username,
            PasswordHash = password 
        };

        try
        {
            await _userRepository.AddUserAsync(newUser);
            Console.WriteLine($"User '{username}' created successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while creating the user: {ex.Message}");
        }
    }
}