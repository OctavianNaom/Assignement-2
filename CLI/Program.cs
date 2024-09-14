namespace CLI.UI;
using InMemoryRepositories;
using RepositoryContracts;

Console.WriteLine("Starting CLI app...");
IUserRepository userRepository= new UserMemoryRepository();
ICommentRepository commentRepository= new CommentMemoryRepository();
IPostRepository postRepository = new PostMemoryRepository();

CliApp cliApp = new CliApp(userRepository, commentRepository, postRepository);
await cliApp.StartAsync();