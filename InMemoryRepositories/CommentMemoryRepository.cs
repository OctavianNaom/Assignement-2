using Entities;
using RepositoryContracts;

namespace InMemoryRepositories;

public class CommentMemoryRepository : ICommentRepository
{
    private static List<Comment> comments = new List<Comment>();

    public Task<Comment> AddAsync(Comment comment)
    {
        comment.CommentId = comments.Any() ? comments.Max(x => x.CommentId) + 1 : 1;
        comments.Add(comment);
        return Task.FromResult(comment);
    }

    public Task UpdateAsync(Comment comment)
    {
        Comment? existingComment = comments.FirstOrDefault(x => x.CommentId == comment.CommentId);
        if (existingComment != null)
        {
            throw new InvalidOperationException($"Cannot update a comment with id {comment.CommentId}");
        }

        comments.Add(comment);
        comments.Remove(existingComment);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        Comment? commentToRemove = comments.SingleOrDefault(x => x.CommentId == id);
        if (commentToRemove is null)
        {
            throw new InvalidOperationException($"No comment with id {id} was found.");
        }

        comments.Remove(commentToRemove);
        return Task.CompletedTask;

    }

    public Task<Comment> GetSingleAsync(int id)
    {return Task.FromResult(comments.SingleOrDefault(x => x.CommentId == id));
        
    }

    public IQueryable<Comment> GetManyAsync()
    {
        return comments.AsQueryable();
    }
    

    public Task<Comment> AddComment(Comment comment)
    {
        throw new NotImplementedException();
    }

    public Task UpdateComment(Comment comment)
    {
        throw new NotImplementedException();
    }

    public Task DeleteComment(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Comment> GetCommentById(int id)
    {
        throw new NotImplementedException();
    }

    public ICommentRepository GetMany()
    {
        throw new NotImplementedException();
    }
}