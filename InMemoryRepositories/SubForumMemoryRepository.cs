using Entities;
using RepositoryContracts;

namespace InMemoryRepositories;

public class SubForumMemoryRepository : ISubForumRepository
{
    private static List<SubForum> subForums = new List<SubForum>();

    public Task<SubForum> AddAsync(SubForum subForum)
    {
        subForum.SubForumId = subForums.Any() ? subForums.Max(x => x.SubForumId) : subForums.Max(x => x.SubForumId);
        subForums.Add(subForum);
        return Task.FromResult(subForum);
    }

    public Task UpdateAsync(SubForum subForum)
    {
        SubForum? existingSubForum = subForums.FirstOrDefault(x => x.SubForumId == subForum.SubForumId);
        if (existingSubForum is null)
        {
            throw new NullReferenceException($"SubForum {subForum.SubForumId} not found");
        }

        subForums.Remove(existingSubForum);
        subForums.Add(subForum);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        SubForum? subForumToRemove=subForums.SingleOrDefault();
        if (subForumToRemove is null)
        {
            throw new InvalidOperationException($"SubForum {id} not found");
        }
        subForums.Remove(subForumToRemove);
        return Task.CompletedTask;
    }

    public Task<SubForum> GetSingleAsync(int id,SubForum subForum)
    {
        return Task.FromResult(subForum);
    }

    public IQueryable<SubForum> GetManyAsync()
    {
        return subForums.AsQueryable();
    }





    public Task<SubForum> AddSubForum(SubForum subForum)
    {
        throw new NotImplementedException();
    }

    public Task UpdateSubForum(SubForum subForum)
    {
        throw new NotImplementedException();
    }

    public Task DeleteSubForum(int id)
    {
        throw new NotImplementedException();
    }

    public Task<SubForum> GetSubForum(int id)
    {
        throw new NotImplementedException();
    }

    public ISubForumRepository GetMany()
    {
        throw new NotImplementedException();
    }
}