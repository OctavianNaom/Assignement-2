namespace CLI.UI.ManagePost;
using RepositoryContracts;
using Entities;
using InMemoryRepositories;
public class CreatePostView
{
    private readonly IPostRepository _postRepository;

    public CreatePostView(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task CreatePostAsync()
    {
        Console.WriteLine("Creating a new post:");

        Console.WriteLine("Enter title:");
        var title = Console.ReadLine();

        Console.WriteLine("Enter content:");
        var content = Console.ReadLine();

        var newPost = new Post
        {
            Title = title,
            Content = content,
        };

        await _postRepository.AddPostAsync(newPost);
        Console.WriteLine("Post created successfully!");
    }
}