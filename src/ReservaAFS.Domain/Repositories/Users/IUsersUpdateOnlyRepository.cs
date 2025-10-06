using ReservaAFS.Domain.Entities;

namespace ReservaAFS.Domain.Repositories.Users;
public interface IUsersUpdateOnlyRepository
{
    Task<User?> GetById(long id);
    void Update(User user);
}
