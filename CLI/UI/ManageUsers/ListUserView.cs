using Microsoft.Extensions.Logging;

namespace CLI.UI.ManageUsers;
using RepositoryContracts;
using InMemoryRepositories;
using Entities;


public class ListUserView
{
    private readonly IUserRepository userRepository;

    public ListUserView(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task DisplayUsersAsync()
    {
       Console.WriteLine("Listing all users");
       var users= userRepository.GetMany();
       foreach (var user in users)
       {
           Console.WriteLine($"username:{user.Username},passwordHash{user.PasswordHash}");
           
       }
    }
}