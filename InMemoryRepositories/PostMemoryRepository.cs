namespace InMemoryRepositories;
using Entities;
using RepositoryContracts;

public class PostMemoryRepository: IPostRepository
{
    private static List<Post> posts = new List<Post>();

    public Task<Post> AddAsync(Post post)
    {
        post.PostId=posts.Any()?posts.Max(x => x.PostId)+1: 1;
        posts.Add(post);
        return Task.FromResult(post);
    }

    public Task UpdateAsync(Post post)
    {
        Post?existingPost = posts.FirstOrDefault(x => x.PostId == post.PostId);
        if (existingPost is null)
        {
            throw new InvalidOperationException($"Post {post.PostId} not found");
        }
        posts.Remove(existingPost);
        posts.Add(post);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        Post? post = posts.SingleOrDefault(x => x.PostId == id);
        if (post is null)
        {
            throw new InvalidOperationException($"Post {id} not found");
        }

        posts.Remove(post);
        return Task.CompletedTask;
    }

    public Task GetsignlesAsync(int id)
    {
        return Task.FromResult(posts.Where(x => x.PostId == id));
    }

    public IQueryable<Post> GetManyAsync()
    {
        return posts.AsQueryable();
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