using Entities;

namespace RepositoryContracts;

public interface IUserRepository
{
    Task<User> AddUser(User user);
    Task UpdateUser(User user);
    Task DeleteUser(int id);
    Task<User> GetUserById(int id);
    IUserRepository GetMany();

}