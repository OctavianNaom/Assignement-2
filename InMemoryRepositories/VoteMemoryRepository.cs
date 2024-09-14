using Entities;
using RepositoryContracts;

namespace InMemoryRepositories;

public class VoteMemoryRepository: IVoteRepository
{
    private static List<Vote> votes = new List<Vote>();

    public Task<Vote> AddAsync(Vote vote)
    {
        vote.VoteId = votes.Any()? votes.Max(v => v.VoteId) + 1 : 1;
        votes.Add(vote);
        return Task.FromResult(vote);
    }

    public Task UpdateAsync(Vote vote)
    {
        Vote? existingVote = votes.SingleOrDefault(v => v.VoteId == vote.VoteId);
        if (existingVote is null)
        {
            throw new InvalidOperationException($"vote with id {vote.VoteId} not found");
        }
        votes.Remove(existingVote);
        votes.Add(vote);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        Vote?voteToRemove = votes.SingleOrDefault(v => v.VoteId == id);
        if (voteToRemove is null)
        {
            throw new InvalidOperationException($"vote with id {id} not found");
        }
        votes.Remove(voteToRemove);
        return Task.CompletedTask;
    }

    public Task<Vote> GetSingleAsync(int id)
    {
        return Task.FromResult(votes.SingleOrDefault(v => v.VoteId == id));
    }

    public IQueryable<Vote> GetManyAsync()
    {
        return votes.AsQueryable();
    }
    
    
    public Task<Vote> AddVote(Vote vote)
    {
        throw new NotImplementedException();
    }

    public Task UpdateVote(Vote vote)
    {
        throw new NotImplementedException();
    }

    public Task DeleteVote(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Vote> GetVote(int id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Vote> GetMany()
    {
        throw new NotImplementedException();
    }
}