// See https://aka.ms/new-console-template for more information
namespace CLI.UI;
using InMemoryRepositories;
using RepositoryContracts;

class Program
{
    static async Task Main(string[] args)
    {
        IUserRepository userRepository = new UserMemoryRepository();
        ICommentRepository commentRepository = new CommentMemoryRepository();
        IPostRepository postRepository = new PostMemoryRepository();
        
        CliApp cliApp = new CliApp(userRepository, commentRepository, postRepository);
        Console.WriteLine("Welcome to the CLI App!");
        await cliApp.StartAsync();
    }
}