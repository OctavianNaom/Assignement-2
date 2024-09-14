using System.Reflection.Metadata;
using Entities;
using RepositoryContracts;
namespace InMemoryRepositories;

public class UserMemoryRepository : IUserRepository
{
    private static List<User> users = new List<User>();

    public Task<User> AddAsynce(User user)
    {
        user.UserId = users.Any()
            ? users.Max(x => x.UserId) + 1
            : 1;
        users.Add(user);
        return Task.FromResult(user);

    }

    public Task UpdateAsync(User user)
    {
        User? existingUser = users.SingleOrDefault(x => x.UserId == user.UserId);
        if (existingUser is null)
        {
            throw new InvalidOperationException($"User with id {user.UserId} not found");
        }

        users.Remove(existingUser);
        users.Add(user);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        User? userToRemove = users.SingleOrDefault(x => x.UserId == id);
        if (userToRemove is null)
        {
            throw new InvalidOperationException($"User with id {id} not found");
        }
        users.Remove(userToRemove);
        return Task.CompletedTask;
    }

    public Task<User> GetSingleAsync(int id, User user)
    {
        return Task.FromResult(user);
    }

    public IQueryable<User> GetManyAsync()
    {
        return users.AsQueryable();
    }
    
    public Task<User> AddUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUser(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserById(int id)
    {
        throw new NotImplementedException();
    }

    public IUserRepository GetMany()
    {
        throw new NotImplementedException();
    }
}