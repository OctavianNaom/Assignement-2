using Entities;

namespace RepositoryContracts;

public interface IVoteRepository
{
    Task<Vote> AddVote(Vote vote);
    Task UpdateVote(Vote vote);
    Task DeleteVote(int id);
    Task<Vote> GetVote(int id);
    IQueryable<Vote> GetMany();
}