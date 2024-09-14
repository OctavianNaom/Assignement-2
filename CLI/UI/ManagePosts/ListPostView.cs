namespace CLI.UI.ManagePost;
using RepositoryContracts;
using InMemoryRepositories;
public class ListPostView
{
    private readonly IPostRepository _postRepository;

    public ListPostView(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task DisplayPostsAsync()
    {
        Console.WriteLine("Listing all posts:");
        
        var posts = await _postRepository.GetAllPostsAsync();

        foreach (var post in posts)
        {
            Console.WriteLine($"ID: {post.PostId}, Title: {post.Title}");
        }
    }
}