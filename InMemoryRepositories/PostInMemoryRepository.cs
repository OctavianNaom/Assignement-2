namespace InMemoryRepositories;
using Entities;
using RepositoryContracts;

public class PostMemoryRepository: IPostRepository
{
    private static List<Post> posts = new List<Post>();

    public Task<Post> AddPostAsync(Post post)
    {
        post.PostId = posts.Any() ? posts.Max(x => x.PostId) + 1 : 1;
        posts.Add(post);
        return Task.FromResult(post);
    }

    public Task UpdatePostAsync(Post post)
    {
        var existingPost = posts.FirstOrDefault(x => x.PostId == post.PostId);
        if (existingPost == null)
        {
            throw new InvalidOperationException($"Post {post.PostId} not found");
        }
        posts.Remove(existingPost);
        posts.Add(post);
        return Task.CompletedTask;
    }

    public Task DeletePostAsync(int id)
    {
        var post = posts.SingleOrDefault(x => x.PostId == id);
        if (post == null)
        {
            throw new InvalidOperationException($"Post {id} not found");
        }
        posts.Remove(post);
        return Task.CompletedTask;
    }

    public Task<Post> GetPostByIdAsync(int id)
    {
        var post = posts.SingleOrDefault(x => x.PostId == id);
        return Task.FromResult(post);
    }

    public Task<IEnumerable<Post>> GetAllPostsAsync()
    {
        return Task.FromResult<IEnumerable<Post>>(posts);
    }
    public Task<Post> AddPost(Post post)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePost(Post post)
    {
        throw new NotImplementedException();
    }

    public Task DeletePost(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Post> GetPostById(int id)
    {
        throw new NotImplementedException();
    }

    public IPostRepository GetMany()
    {
        throw new NotImplementedException();
    }
}