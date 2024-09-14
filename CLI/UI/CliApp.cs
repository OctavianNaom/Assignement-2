using CLI.UI.ManagePost;
using RepositoryContracts;
using InMemoryRepositories;
namespace CLI.UI;

public class CliApp
{
    private readonly IUserRepository _userRepository;
    private readonly ICommentRepository _commentRepository;
    private readonly IPostRepository _postRepository;

    public CliApp(IUserRepository userRepository, ICommentRepository commentRepository, IPostRepository postRepository)
    {
        _userRepository = userRepository;
        _commentRepository = commentRepository;
        _postRepository = postRepository;
    }

    public async Task StartAsync()
    {
        Console.WriteLine("Welcome to the CLI App!");

        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Manage Users");
            Console.WriteLine("2. Manage Posts");
            Console.WriteLine("0. Exit");

            var choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("Manage Users - Feature not implemented");
            }
            else if (choice == "2")
            {
                var managePostsView = new ManagePostsView(_postRepository);
                await managePostsView.DisplayAsync();
            }
            else if (choice == "0")
            {
                Console.WriteLine("Exiting...");
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
            }
        }
    }
}