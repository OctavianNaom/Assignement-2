namespace CLI.UI.ManagePost;
using RepositoryContracts;
using InMemoryRepositories;
public class SinglePostView
{
    private readonly IPostRepository _postRepository;
    private readonly int _postId;

    public SinglePostView(IPostRepository postRepository, int postId)
    {
        _postRepository = postRepository;
        _postId = postId;
    }

    public async Task DisplayPostAsync()
    {
        // Correct method name
        var post = await _postRepository.GetPostByIdAsync(_postId);

        if (post != null)
        {
            Console.WriteLine($"Title: {post.Title}");
            Console.WriteLine($"Content: {post.Content}");
            Console.WriteLine($"Content: {post.Comments}");
        }
        else
        {
            Console.WriteLine("Post not found.");
        }
    }
}