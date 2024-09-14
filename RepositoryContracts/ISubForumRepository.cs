using Entities;

namespace RepositoryContracts;

public interface ISubForumRepository
{Task <SubForum> AddSubForum(SubForum subForum);
    Task UpdateSubForum(SubForum subForum);
    Task DeleteSubForum(int id);
    Task<SubForum> GetSubForum(int id);
    ISubForumRepository GetMany();

}