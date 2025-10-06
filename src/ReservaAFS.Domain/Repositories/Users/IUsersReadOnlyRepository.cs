using ReservaAFS.Domain.Entities;

namespace ReservaAFS.Domain.Repositories.Users;
public interface IUsersReadOnlyRepository
{
    Task<List<User>> GetAll();
    Task<User?> GetById(long id);
}
