/*namespace CLI.UI.ManagePost;
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

        var posts = await _postRepository.GetPostsAsync();

        foreach (var post in posts)
        {
            Console.WriteLine($"ID: {post.Id}, Title: {post.Title}, Created: {post.DateCreated}");
        }
    }
}*/